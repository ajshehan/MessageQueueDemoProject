using MessageQueueManager.DataModels;
using MessageQueueManager.Interfaces;
using System;
using System.Threading.Tasks;

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

        public async Task<MessageQueueConfigurations> GetQueueConfigurations(string messageQueueName)
        {
            if (_queueConfigurations != null)
            {
                return _queueConfigurations;
            }

            var results = await _settingsManager.GetMessageQueueConfigurations(messageQueueName);
            _queueConfigurations = results;

            CreateMessageQueuePath();

            return _queueConfigurations;
        }

        private void CreateMessageQueuePath()
        {
            _queueConfigurations.Path = $"{Environment.MachineName}\\{(_queueConfigurations.IsPrivateQueue ? "Private$\\" : string.Empty)}{_queueConfigurations.Name}";
        }
    }
}
