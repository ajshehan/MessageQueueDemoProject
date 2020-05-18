using System;

namespace MessageQueueManager.Interfaces
{
    public interface ILogService
    {
        void Info(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");

        void Info(string message, object dataObject, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");

        void Error(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");

        void Error(Exception ex, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");

        void Error(string message, Exception ex, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");            

        void Warning(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "");
    }
}
