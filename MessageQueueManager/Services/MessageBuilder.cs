using MessageQueueManager.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Messaging;
using System.Text;

namespace MessageQueueManager.Services
{
    public class MessageBuilderService : IMessageBuilderService
    {
        public Message CreateMesasge(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return new Message
            {
                BodyStream = SerializeToJsonMessage(message)
            };
        }

        public string GetMesasgeContent(Message message)
        {
            if (message == null)
            {
                return string.Empty;
            }

            return DeserializeToJsonMessage(message);
        }

        private string DeserializeToJsonMessage(Message message)
        {
            var messageReader = new StreamReader(message.BodyStream);
            var jsonBody = messageReader.ReadToEnd();
            return JsonConvert.DeserializeObject<string>(jsonBody);
        }

        private Stream SerializeToJsonMessage(string message)
        {
            var jsonResult = JsonConvert.SerializeObject(message);
            return new MemoryStream(Encoding.Default.GetBytes(jsonResult));
        }
    }
}
