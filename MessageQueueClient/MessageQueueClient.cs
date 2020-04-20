using System;
using System.Windows.Forms;
using MessageQueueManager.Services;

namespace MessageQueueClient
{
    public partial class MessageQueueClient : Form
    {
        private const string _paymentsQueueName = "EmailCampainRegistrationQueue";

        private readonly MessageQueueService _messageQueueService;

        public MessageQueueClient()
        {
            InitializeComponent();
            _messageQueueService = new MessageQueueService();
        }
        
        private void btn_send_message_Click(object sender, EventArgs e)
        {
            _messageQueueService.SendMessage(_paymentsQueueName, tb_message.Text);
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            var message = _messageQueueService.ReadMessage(_paymentsQueueName);
            tb_received_messages.Text = $"{tb_received_messages.Text} \n {message}";
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_message.Text = string.Empty;
            tb_received_messages.Text = string.Empty;
        }
    }
}
