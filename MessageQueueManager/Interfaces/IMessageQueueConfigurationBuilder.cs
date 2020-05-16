using MessageQueueManager.DataModels;

namespace MessageQueueManager.Interfaces
{
    public interface IMessageQueueConfigurationBuilder
    {
        MessageQueueConfigurations GetQueueConfigurations(string messageQueueName);
    }
}
