using MessageQueueManager.DataModels;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace MessageQueueManager.Services
{
    public static class SettingsManager
    {
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

        public static string GetStringSetting(string queueName, string settingName)
        {
            var configurationItem = ConfigurationsList.MessageQueueConfigurations.FirstOrDefault(i => i.Name.ToLowerInvariant().Equals(queueName.ToLowerInvariant()));
            if (configurationItem == null)
            {
                return string.Empty;
            }

            var property = configurationItem.GetType().GetProperty(settingName);
            if (property == null && (property.GetType() != typeof(string) || property.GetType() != typeof(String)))
            {
                return string.Empty;
            }

            return property.GetValue(configurationItem, null).ToString();
        }

        public static bool GetBoolSetting(string queueName, string settingName)
        {
            var configurationItem = ConfigurationsList?.MessageQueueConfigurations.FirstOrDefault(i => i.Name.ToLowerInvariant().Equals(queueName.ToLowerInvariant()));
            if(configurationItem == null)
            {
                return false;
            }

            var property = configurationItem.GetType().GetProperty(settingName);
            if(property == null && (property.GetType() != typeof(bool) || property.GetType() != typeof(Boolean)))
            {
                return false;
            }

            var value = property.GetValue(configurationItem, null).ToString();
            if(bool.TryParse(value,out var convertedValue))
            {
                return convertedValue;
            }

            return false;
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
