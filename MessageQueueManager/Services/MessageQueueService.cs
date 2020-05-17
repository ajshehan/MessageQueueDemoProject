﻿using MessageQueueManager.Interfaces;
using System;
using System.Messaging;
using System.Threading.Tasks;

namespace MessageQueueManager.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly int TimeToPause = 20;

        private IMessageQueueConfigurationBuilder _messageQueueConfigurationBuilder;
        private IMessageBuilderService _messageBuilderService;

        public MessageQueueService() : this(new MessageQueueConfigurationBuilder(), new MessageBuilderService())
        {

        }

        public MessageQueueService(IMessageQueueConfigurationBuilder messageQueueConfigurationBuilder,
            IMessageBuilderService messageBuilderService)
        {
            _messageQueueConfigurationBuilder = messageQueueConfigurationBuilder;
            _messageBuilderService = messageBuilderService;
        }

        public async Task<bool> SendMessageAsync(string queueName, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return false;
            }

            var messageQueue = await GetOrCreateMessageQueue(queueName);
            if (messageQueue == null)
            {
                return false;
            }

            var messageQueueMessage = _messageBuilderService.CreateMesasge(message);
            if (messageQueueMessage == null)
            {
                return false;
            }

            await Task.Run(() =>
            {
                messageQueue.Send(messageQueueMessage);
            });

            return true;
        }

        public async Task<string> ReadMessageAsync(string queueName)
        {
            var messageQueue = await GetMessageQueue(queueName);
            if (messageQueue == null)
            {
                return string.Empty;
            }

            var message = await Task.Run(() =>
            {
                return messageQueue.Receive(TimeSpan.FromSeconds(TimeToPause), MessageQueueTransactionType.Single);
            });

            if (message == null)
            {
                return string.Empty;
            }

            return _messageBuilderService.GetMesasgeContent(message);
        }

        public bool IsExist(string queueName)
        {
            if (GetMessageQueue(queueName) == null)
            {
                return false;
            }

            return true;
        }

        private async Task<MessageQueue> GetOrCreateMessageQueue(string queueName)
        {
            var messageQueue = await GetMessageQueue(queueName);

            if (messageQueue == null)
            {
                messageQueue = await CreateMessageQueue(queueName);
            }

            return messageQueue;
        }

        private async Task<MessageQueue> GetMessageQueue(string queueName)
        {
            var messageQueueConfigurations = await _messageQueueConfigurationBuilder.GetQueueConfigurations(queueName);

            if (!MessageQueue.Exists(messageQueueConfigurations.Path))
            {
                return null;
            }

            return new MessageQueue(messageQueueConfigurations.Path);
        }

        private async Task<MessageQueue> CreateMessageQueue(string queueName)
        {
            var messageQueueConfigurations = await _messageQueueConfigurationBuilder.GetQueueConfigurations(queueName);

            if (messageQueueConfigurations == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(messageQueueConfigurations.Path))
            {
                return null;
            }

            var messageQueue = await GetMessageQueue(messageQueueConfigurations.Name);
            if (messageQueue != null)
            {
                return messageQueue;
            }

            await Task.Run(() =>
                messageQueue = MessageQueue.Create(messageQueueConfigurations.Path)
            );

            if (messageQueue == null)
            {
                return null;
            }

            return messageQueue;
        }
    }
}
