namespace MessageQueueManager.DataModels
{
    public class MessageQueueConfigurations
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public bool IsPrivateQueue { get; set; }
        public bool IsTcpEnabled { get; set; }
        public bool IsTransactional { get; set; }
        public bool IsPersistQueueEnabled { get; set; }
        public string Path { get; set; }
    }
}
