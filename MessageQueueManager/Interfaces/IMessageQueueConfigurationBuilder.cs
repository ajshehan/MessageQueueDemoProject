using MessageQueueManager.DataModels;
using System.Threading.Tasks;

namespace MessageQueueManager.Interfaces
{
    public interface IMessageQueueConfigurationBuilder
    {
        Task<MessageQueueConfigurations> GetQueueConfigurations(string messageQueueName);
    }
}
