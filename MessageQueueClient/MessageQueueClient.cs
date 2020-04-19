using MessageQueueManager;
using System;
using System.Windows.Forms;

namespace MessageQueueClient
{
    public partial class MessageQueueClient : Form
    {
        private const string messageQueueName = "ajqueue";

        private MessageQueueManager.MessageQueueManager _messageQueueService;

        public MessageQueueClient()
        {
            InitializeComponent();
            InitializeMessageQueue();
        }


        private void btn_send_message_Click(object sender, EventArgs e)
        {
            _messageQueueService.SendMessage(tb_message.Text);
        }

        private void InitializeMessageQueue()
        {
            _messageQueueService = new MessageQueueManager.MessageQueueManager();
            _messageQueueService.CreateMessageQueue(messageQueueName);
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            tb_received_messages.Text = $"{tb_received_messages.Text} \n {_messageQueueService.ReadMessage()}";
        }
    }
}
