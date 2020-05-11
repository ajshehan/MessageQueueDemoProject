using MessageQueueManager.Interfaces;
using MessageQueueManager.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageQueueClient
{
    public partial class MessageQueueClient : Form
    {
        private const string _paymentsQueueName = "PaymentQueue";

        private readonly IMessageQueueService _messageQueueService;

        public MessageQueueClient()
        {
            InitializeComponent();
            _messageQueueService = new MessageQueueService();
        }

        private void btn_send_message_Click(object sender, EventArgs e)
        {
            _ = Task.Run(async () =>
                  await _messageQueueService.SendMessageAsync(_paymentsQueueName, tb_message.Text)
            );
        }

        private async void btn_read_Click(object sender, EventArgs e)
        {
            var message = await _messageQueueService.ReadMessageAsync(_paymentsQueueName);

            tb_received_messages.Text = $"{tb_received_messages.Text} \n {message}";
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_message.Text = string.Empty;
            tb_received_messages.Text = string.Empty;
        }
    }
}
