using MessageQueueManager.Interfaces;
using MessageQueueManager.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MessageQueueManager.Tests.Services
{
    [TestFixture]
    public class MessageQueueServiceTests
    {
        private const string MessageQueueName = "";

        private Mock<IMessageQueueConfigurationBuilder> _messageQueueConfigurationBuilder;
        private Mock<IMessageBuilderService> _messageBuilderService;

        private IMessageQueueService _service;

        [SetUp]
        public void Setup()
        {
            _messageQueueConfigurationBuilder = new Mock<IMessageQueueConfigurationBuilder>();
            _messageBuilderService = new Mock<IMessageBuilderService>();

            _service = new MessageQueueService(
                _messageQueueConfigurationBuilder.Object,
                _messageBuilderService.Object
                );
        }

        [Test]
        public async void SendMessageAsync_GivenMessageNull_ReturnFalse()
        {
            //Arrange
            string message = null;

            //Act
            var result = await _service.SendMessageAsync(MessageQueueName, message);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async void SendMessageAsync_GivenMessageEmpty_ReturnFalse()
        {
            //Arrange
            var message = string.Empty;

            //Act
            var result = await _service.SendMessageAsync(MessageQueueName, message);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async void SendMessageAsync_GivenMessage_ReturnTrue()
        {
            //Arrange
            var message = string.Empty;

            //Act
            var result = await _service.SendMessageAsync(MessageQueueName, message);

            //Assert
            Assert.That(result, Is.True);
        }
    }
}

