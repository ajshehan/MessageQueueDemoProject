using MessageQueueManager.DataModels;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQueueManager.Services
{
    public static class SettingsManager
    {
        //TODO:  move to a configuration file
        private static string _configuationFilePath = @"F:\Sample Projects\MessageQueueDemoProject\MessageQueueManager\App_Config\MessageQueueConfigurations.json";
        private static ConfigurationsList _configurationsList { get; set; }

        private async static Task<ConfigurationsList> GetConfigurationsList()
        {
            if (_configurationsList == null)
            {
                return _configurationsList = await GetSettingsObject();
            }

            return _configurationsList;
        }

        public async static Task<MessageQueueConfigurations> GetMessageQueueConfigurations(string queueName)
        {
            var configurationsList = await GetConfigurationsList();

            return configurationsList.MessageQueueConfigurations
               .FirstOrDefault(i => i.Name.ToLowerInvariant().Equals(queueName.ToLowerInvariant()));
        }

        private async static Task<ConfigurationsList> GetSettingsObject()
        {
            var settingsFileCotnent = await ReadConfigurationFile();
            var settingsObject = JsonConvert.DeserializeObject<ConfigurationsList>(settingsFileCotnent);

            return settingsObject;
        }

        private async static Task<string> ReadConfigurationFile()
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
