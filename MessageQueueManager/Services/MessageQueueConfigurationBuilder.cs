using MessageQueueManager.DataModels;
using System;

namespace MessageQueueManager.Services
{
    public static class MessageQueueConfigurationBuilder
    {
        private static MessageQueueConfigurations _queueConfigurations;

        public static MessageQueueConfigurations GetQueueConfigurations(string messageQueueName)
        {
            if (_queueConfigurations == null)
            {
                _queueConfigurations = SettingsManager.GetMessageQueueConfigurations(messageQueueName);
                CreateMessageQueuePath();
            }

            return _queueConfigurations;
        }

        private static void CreateMessageQueuePath()
        {
            _queueConfigurations.Path = $"{Environment.MachineName}\\{(_queueConfigurations.IsPrivateQueue ? "Private$\\" : string.Empty)}{_queueConfigurations.Name}";
        }
    }
}
