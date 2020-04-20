using System.Collections.Generic;

namespace MessageQueueManager.DataModels
{
    public class ConfigurationsList
    {
        public List<MessageQueueConfigurations> MessageQueueConfigurations { get; set; }
    }

    public class MessageQueueConfigurations
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string IsPrivateQueue { get; set; }
        public bool IsTcpEnabled { get; set; }
        public bool IsTransactional { get; set; }
        public bool IsPersistQueueEnabled { get; set; }
    }
}
