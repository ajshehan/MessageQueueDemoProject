﻿using MessageQueueManager.DataModels;
using MessageQueueManager.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Messaging;
using System.Text;

namespace MessageQueueManager.Services
{
    public class MessageQueueManager : IMessageQueueManager
    {
        private MessageQueue _messageQueue;
        private MessageQueueContext _messageQueueContext;

        public bool CreateMessageQueue(string queueName)
        {
            _messageQueueContext = MessageQueueContextBuilder.GetContext(queueName);

            if (string.IsNullOrEmpty(_messageQueueContext.Path))
            {
                return false;
            }

            if (MessageQueue.Exists(_messageQueueContext.Path))
            {
                _messageQueue = new MessageQueue(_messageQueueContext.Path);
                return true;
            }

            _messageQueue = MessageQueue.Create(_messageQueueContext.Path);

            if (_messageQueue == null)
            {
                return false;
            }

            return true;
        }

        public bool IsExist(string queueName)
        {
            _messageQueueContext = MessageQueueContextBuilder.GetContext(queueName);

            if (string.IsNullOrEmpty(_messageQueueContext.Path))
            {
                return false;
            }

            if (MessageQueue.Exists(_messageQueueContext.Path))
            {
                _messageQueue = new MessageQueue(_messageQueueContext.Path);
                return true;
            }

            return false;
        }

        public bool SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return false;
            }

            if (_messageQueue == null)
            {
                return false;
            }

            var messageQueueMessage = CreateMesasge(message);
            if (messageQueueMessage == null)
            {
                return false;
            }

            _messageQueue.Send(messageQueueMessage);

            return true;
        }

        public bool SendTransactionalMessage(string message)
        {
            return true;
        }

        public string ReadMessage()
        {
            if (_messageQueue == null)
            {
                return string.Empty;
            }

            if (!MessageQueue.Exists(_messageQueue.Path))
            {
                return string.Empty;
            }

            var message = _messageQueue.Receive(TimeSpan.FromSeconds(20), MessageQueueTransactionType.Single);

            if (message == null)
            {
                return string.Empty;
            }
            return DeserializeToJsonMessage(message);
        }

        private Message CreateMesasge(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return new Message
            {
                BodyStream = SerializeToJsonMessage(message)
            };
        }

        private MemoryStream SerializeToJsonMessage(string message)
        {
            var jsonResult = JsonConvert.SerializeObject(message);
            return new MemoryStream(Encoding.Default.GetBytes(jsonResult));
        }

        private string DeserializeToJsonMessage(Message message)
        {
            var messageReader = new StreamReader(message.BodyStream);
            var jsonBody = messageReader.ReadToEnd();
            return JsonConvert.DeserializeObject<string>(jsonBody);
        }
    }
}
