using Newtonsoft.Json;
using System.IO;
using System.Messaging;
using System.Text;

namespace MessageQueueManager.Services
{
    public class MessageBuilder
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

        private Stream SerializeToJsonMessage(string message)
        {
            var jsonResult = JsonConvert.SerializeObject(message);
            return new MemoryStream(Encoding.Default.GetBytes(jsonResult));
        }

        public string DeserializeToJsonMessage(Message message)
        {
            var messageReader = new StreamReader(message.BodyStream);
            var jsonBody = messageReader.ReadToEnd();
            return JsonConvert.DeserializeObject<string>(jsonBody);
        }
    }
}
