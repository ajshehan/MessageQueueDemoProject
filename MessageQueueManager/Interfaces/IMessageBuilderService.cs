using System.Messaging;

namespace MessageQueueManager.Interfaces
{
    public interface IMessageBuilderService
    {
        Message CreateMesasge(string message);
        
        string GetMesasgeContent(Message message);
    }
}
