using Newtonsoft.Json;
using System.IO;
using System.Messaging;
using System.Text;

namespace MessageQueueManager.Services
{
    public static class MessageBuilder
    {
        public static Message CreateMesasge(string message)
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

        public static string GetMesasgeContent(Message message)
        {
            if (message == null)
            {
                return string.Empty;
            }

            return DeserializeToJsonMessage(message);
        }

        private static string DeserializeToJsonMessage(Message message)
        {
            var messageReader = new StreamReader(message.BodyStream);
            var jsonBody = messageReader.ReadToEnd();
            return JsonConvert.DeserializeObject<string>(jsonBody);
        }

        private static Stream SerializeToJsonMessage(string message)
        {
            var jsonResult = JsonConvert.SerializeObject(message);
            return new MemoryStream(Encoding.Default.GetBytes(jsonResult));
        }
    }
}
