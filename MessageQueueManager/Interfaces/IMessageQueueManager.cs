namespace MessageQueueManager.Interfaces
{
    public interface IMessageQueueManager
    {
        bool CreateMessageQueue(string queueName);
        bool SendMessage(string message);
        string ReadMessage();
    }
}
