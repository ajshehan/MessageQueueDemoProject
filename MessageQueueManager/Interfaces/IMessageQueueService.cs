using System.Threading.Tasks;

namespace MessageQueueManager.Interfaces
{
    public interface IMessageQueueService
    {
        Task<bool> SendMessageAsync(string queueName, string message);

        Task<string> ReadMessageAsync(string queueName);

        bool IsExist(string queueName);
    }
}
