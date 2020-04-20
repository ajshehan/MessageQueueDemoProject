using MessageQueueManager.DataModels;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace MessageQueueManager.Services
{
    public static class SettingsManager
    {
        //TODO:  move to a configuration file
        private static string _configuationFilePath = @"F:\Sample Projects\MessageQueueDemoProject\MessageQueueManager\App_Config\MessageQueueConfigurations.json";
        private static ConfigurationsList _configurationsList { get; set; }
        private static ConfigurationsList ConfigurationsList
        {
            get
            {
                if(_configurationsList == null)
                {
                    return _configurationsList = GetSettingsObject();
                }

                return _configurationsList;
            }
        }

        public static MessageQueueConfigurations GetMessageQueueConfigurations(string queueName)
        {
             return ConfigurationsList.MessageQueueConfigurations
                .FirstOrDefault(i => i.Name.ToLowerInvariant().Equals(queueName.ToLowerInvariant()));
        }

        private static ConfigurationsList GetSettingsObject()
        {
            var settingsObject = JsonConvert.DeserializeObject<ConfigurationsList>(ReadConfigurationFile());
            return settingsObject;
        }

        private static string ReadConfigurationFile()
        {
            if(!File.Exists(_configuationFilePath))
            {
                return string.Empty;
            }

            return File.ReadAllText(_configuationFilePath);
        }
    }
}
