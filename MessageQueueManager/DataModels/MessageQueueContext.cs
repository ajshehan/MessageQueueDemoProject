namespace MessageQueueManager.DataModels
{
    public class MessageQueueContext
    {
        public bool IsPrivateQueue { get; internal set; }
        public string IpAddress { get; internal set; }
        public string Name { get; internal set; }
        public string Path { get; internal set; }
    }
}
