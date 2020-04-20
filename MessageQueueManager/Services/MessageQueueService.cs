using MessageQueueManager.Interfaces;
using System;
using System.Messaging;

namespace MessageQueueManager.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly int TimeToPause = 20;

        public bool SendMessage(string queueName, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return false;
            }

            var messageQueue = GetOrCreateMessageQueue(queueName);
            if (messageQueue == null)
            {
                return false;
            }

            var messageQueueMessage = MessageBuilder.CreateMesasge(message);
            if (messageQueueMessage == null)
            {
                return false;
            }

            messageQueue.Send(messageQueueMessage);

            return true;
        }

        public string ReadMessage(string queueName)
        {
            var messageQueue = GetMessageQueue(queueName);
            if (messageQueue == null)
            {
                return string.Empty;    
            }

            var message = messageQueue.Receive(TimeSpan.FromSeconds(TimeToPause), MessageQueueTransactionType.Single);
            if (message == null)
            {
                return string.Empty;
            }

            return MessageBuilder.GetMesasgeContent(message);
        }

        public bool IsExist(string queueName)
        {
            if (GetMessageQueue(queueName) == null)
            {
                return false;
            }

            return true;
        }

        private MessageQueue GetOrCreateMessageQueue(string queueName)
        {
            var messageQueue = GetMessageQueue(queueName);

            if (messageQueue == null)
            {
                messageQueue = CreateMessageQueue(queueName);
            }

            return messageQueue;
        }

        private MessageQueue GetMessageQueue(string queueName)
        {
            var messageQueueConfigurations = MessageQueueConfigurationBuilder.GetQueueConfigurations(queueName);

            if (!MessageQueue.Exists(messageQueueConfigurations.Path))
            {
                return null;
            }

            return new MessageQueue(messageQueueConfigurations.Path);
        }

        private MessageQueue CreateMessageQueue(string queueName)
        {
            var messageQueueConfigurations = MessageQueueConfigurationBuilder.GetQueueConfigurations(queueName);

            if (messageQueueConfigurations == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(messageQueueConfigurations.Path))
            {
                return null;
            }

            var messageQueue = GetMessageQueue(messageQueueConfigurations.Name);
            if (messageQueue != null)
            {
                return messageQueue;
            }

            messageQueue = MessageQueue.Create(messageQueueConfigurations.Path);
            if (messageQueue == null)
            {
                return null;
            }

            return messageQueue;
        }
    }
}
