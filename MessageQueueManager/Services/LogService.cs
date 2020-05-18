using MessageQueueManager.Interfaces;
using Newtonsoft.Json;
using System;

namespace MessageQueueManager.Services
{
    public class LogService : ILogService
    {
        private readonly log4net.ILog _logger;

        public LogService()
        {
            _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Info(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            _logger.Info(FormatMessage(message, memberName));
        }

        public void Info(string message, object dataObject, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            _logger.Info(SerializedMessage(message, dataObject, memberName));
        }

        public void Error(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            _logger.Error(FormatMessage(message, memberName));
        }

        public void Error(Exception ex, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            LogException(ex, memberName);
        }

        public void Error(string message, Exception ex, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            _logger.Info(FormatMessage(message, memberName));
            LogException(ex, memberName);
        }

        public void Warning(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            _logger.Warn(FormatMessage(message, memberName));
        }

        private void LogException(Exception ex, string memberName)
        {
            _logger.Error(FormatMessage(ex.Message, memberName));
            _logger.Error(FormatMessage(ex.StackTrace, memberName));
            if (ex.InnerException != null)
            {
                _logger.Error(FormatMessage(ex.InnerException.Message, memberName));
                _logger.Error(FormatMessage(ex.InnerException.StackTrace, memberName));
            }
        }

        private string FormatMessage(string message, string memberName)
        {
            return $"{message} - caller: {memberName}";
        }

        private string SerializedMessage(string message, object dataObject, string memberName)
        {
            var messageObject = new
            {
                Message = message,
                Function = memberName,
                Data = dataObject
            };

            return JsonConvert.SerializeObject(messageObject, Formatting.Indented).ToString();
        }
    }
}
