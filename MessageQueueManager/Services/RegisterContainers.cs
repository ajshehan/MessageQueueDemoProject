using Autofac;
using MessageQueueManager.Interfaces;

namespace MessageQueueManager.Services
{
    public class RegisterContainers
    {
        public void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LogService>().As<ILogService>();
            builder.RegisterType<MessageQueueConfigurationBuilder>().As<IMessageQueueConfigurationBuilder>();
            builder.RegisterType<MessageQueueService>().As<IMessageQueueService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>();

            builder.Build();
        }
    }
}
