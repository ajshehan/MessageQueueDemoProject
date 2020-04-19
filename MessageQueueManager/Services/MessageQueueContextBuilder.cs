using MessageQueueManager.Constants;
using MessageQueueManager.DataModels;
using System;

namespace MessageQueueManager.Services
{
    public class MessageQueueContextBuilder
    {
        public static MessageQueueContext GetContext(string messageQueueName)
        {
            return new MessageQueueContext
            {
                Name = messageQueueName,
                Path = CreateMessageQueuePath(messageQueueName)
            };
        }

        private static string CreateMessageQueuePath(string messageQueueName)
        {
            if (string.IsNullOrEmpty(messageQueueName))
            {
                return string.Empty;
            }

            return $"{Environment.MachineName}\\{(IsPrivateQueue() ? "Private$\\" : string.Empty)}{messageQueueName}";
            //return $"DIRECT=TCP:127.0.0.1\\{(isPrivateQueue ? "Private$\\" : string.Empty)}{queueName}";
            //return $"OS:{Environment.MachineName}\\{(IsPrivateQueue ? "Private$\\" : string.Empty)}{messageQueueName}";
        }
        
        private static bool IsPrivateQueue()
        {
            return SettingsManager.GetBool(AppSettingsKeys.IsPrivateQueue);
        }

        private bool IsTcpEnabled()
        {
            return false;
        }

        private bool IsPersistQueueEnabled()
        {
            return true;
        }

    }
}
