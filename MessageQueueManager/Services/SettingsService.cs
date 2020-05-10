using MessageQueueManager.DataModels;
using MessageQueueManager.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQueueManager.Services
{
    public class SettingsService : ISettingsService
    {
        //TODO:  move to a configuration file
        private static string _configuationFilePath = @"F:\Sample Projects\MessageQueueDemoProject\MessageQueueManager\App_Config\MessageQueueConfigurations.json";
        private ConfigurationsList _configurationsList { get; set; }

        public async Task<MessageQueueConfigurations> GetMessageQueueConfigurations(string queueName)
        {
            var configurationsList = await GetConfigurationsList();

            return configurationsList.MessageQueueConfigurations
               .FirstOrDefault(i => i.Name.ToLowerInvariant().Equals(queueName.ToLowerInvariant()));
        }

        private async Task<ConfigurationsList> GetConfigurationsList()
        {
            if (_configurationsList == null)
            {
                return _configurationsList = await GetSettingsObject();
            }

            return _configurationsList;
        }

        private async Task<ConfigurationsList> GetSettingsObject()
        {
            var settingsFileCotnent = await ReadConfigurationFile();
            var settingsObject = JsonConvert.DeserializeObject<ConfigurationsList>(settingsFileCotnent);

            return settingsObject;
        }

        private async Task<string> ReadConfigurationFile()
        {
            if (!File.Exists(_configuationFilePath))
            {
                return string.Empty;
            }

            var fileContent = await Task.Run(() => File.ReadAllText(_configuationFilePath));

            return fileContent;
        }
    }
}
