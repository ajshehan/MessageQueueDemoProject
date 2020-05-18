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

        private Mock<IMessageQueueConfigurationBuilder> _messageQueueConfigurationBuilderMock;
        private Mock<IMessageBuilderService> _messageBuilderServiceMock;

        private IMessageQueueService _service;

        [SetUp]
        public void Setup()
        {
            _messageQueueConfigurationBuilderMock = new Mock<IMessageQueueConfigurationBuilder>();
            _messageBuilderServiceMock = new Mock<IMessageBuilderService>();

            _service = new MessageQueueService(
                _messageQueueConfigurationBuilderMock.Object,
                _messageBuilderServiceMock.Object
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

            _messageQueueConfigurationBuilderMock
                .Setup(x => x.GetQueueConfigurations(It.IsAny<string>()))
                .Returns(Task.FromResult(new DataModels.MessageQueueConfigurations { 
                    Name = MessageQueueName,
                    Path = "",
                    IsPrivateQueue = true
                }));

            //Act
            var result = await _service.SendMessageAsync(MessageQueueName, message);

            //Assert
            Assert.That(result, Is.True);
        }
    }
}

