namespace MessageQueueManager.Interfaces
{
    public interface IMessageQueueService
    {
        bool SendMessage(string queueName, string message);

        string ReadMessage(string queueName);
    }
}
