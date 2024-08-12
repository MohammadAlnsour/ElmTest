using Serilog;

namespace ElmTest.Shared.AppExceptions
{
    public static class AppExceptionHandler
    {
        public static void HandleException(this Exception exception, ILogger logger)
        {
            if (exception != null)
            {
                logger.Error($"exception occured {exception.Message} , stackTrace {exception.StackTrace}");
                
                //Notify interested parties ...
                var onerror = new OnErrorEvent(new List<IErrorNotificationParty>() { new ExceptionEmail() });
                onerror.AppExecptionOccured();
            }
        }
    }
}
