namespace MessageQueueManager.Interfaces
{
    public interface IMessageQueueManager
    {
        bool SendMessage(string message);
        string ReadMessage();
    }
}
