using MessageQueueManager.DataModels;
using MessageQueueManager.Interfaces;
using System;

namespace MessageQueueManager.Services
{
    public class MessageQueueConfigurationBuilder : IMessageQueueConfigurationBuilder
    {
        private MessageQueueConfigurations _queueConfigurations;
        private ISettingsService _settingsManager;

        public MessageQueueConfigurationBuilder() : this(new SettingsService())
        {

        }

        public MessageQueueConfigurationBuilder(ISettingsService settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public MessageQueueConfigurations GetQueueConfigurations(string messageQueueName)
        {
            if (_queueConfigurations != null)
            {
                return _queueConfigurations;
            }

            var results = _settingsManager.GetMessageQueueConfigurations(messageQueueName);
            _queueConfigurations = results.Result;

            CreateMessageQueuePath();

            return _queueConfigurations;
        }

        private void CreateMessageQueuePath()
        {
            _queueConfigurations.Path = $"{Environment.MachineName}\\{(_queueConfigurations.IsPrivateQueue ? "Private$\\" : string.Empty)}{_queueConfigurations.Name}";
        }
    }
}
