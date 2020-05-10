using MessageQueueManager.DataModels;
using System.Threading.Tasks;

namespace MessageQueueManager.Interfaces
{
    public interface ISettingsService
    {
        Task<MessageQueueConfigurations> GetMessageQueueConfigurations(string queueName);
    }
}
