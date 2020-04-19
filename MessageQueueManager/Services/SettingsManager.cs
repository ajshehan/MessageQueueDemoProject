using System.Configuration;

namespace MessageQueueManager.Services
{
    public static class SettingsManager
    {
        public static bool GetBool(string appSettingKey)
        {
            var value = ConfigurationManager.AppSettings[appSettingKey];
            if(bool.TryParse(value, out bool convertedValue))
            {
                return convertedValue;
            }
            return false;
        }
    }
}
