using MessageQueueManager.DataModels;
using System;

namespace MessageQueueManager.Services
{
    public class MessageQueueConfigurationBuilder
    {
        public static MessageQueueConfigurations GetQueueConfigurations(string messageQueueName)
        {
            var queueConfigurations = SettingsManager.GetMessageQueueConfigurations(messageQueueName);
            if (queueConfigurations == null)
            {
                return null;
            }

            CreateMessageQueuePath(queueConfigurations);

            return queueConfigurations;
        }

        private static void CreateMessageQueuePath(MessageQueueConfigurations queueConfigurations)
        {
            queueConfigurations.Path = $"{Environment.MachineName}\\{(queueConfigurations.IsPrivateQueue ? "Private$\\" : string.Empty)}{queueConfigurations.Name}";
        }
    }
}
