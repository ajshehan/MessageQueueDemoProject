using MessageQueueManager.DataModels;
using MessageQueueManager.Interfaces;
using System;
using System.Messaging;

namespace MessageQueueManager.Services
{
    public class MessageQueueManager : IMessageQueueManager
    {
        private MessageQueue _messageQueue;
        private MessageQueueContext _messageQueueContext;
        private MessageBuilder _messageBuilder;

        public MessageQueueManager()
        {
            _messageBuilder = new MessageBuilder();
        }

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

            var messageQueueMessage = _messageBuilder.CreateMesasge(message);
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
            if (!MessageQueue.Exists(_messageQueue.Path))
            {
                return string.Empty;
            }

            var message = _messageQueue.Receive(TimeSpan.FromSeconds(20), MessageQueueTransactionType.Single);

            if (message == null)
            {
                return string.Empty;
            }

            return _messageBuilder.DeserializeToJsonMessage(message);
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
    }
}
