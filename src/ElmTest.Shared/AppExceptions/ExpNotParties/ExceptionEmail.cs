namespace ElmTest.Shared.AppExceptions.ExpNotParties
{
    public class ExceptionEmail : IErrorNotificationParty
    {
        public ExceptionEmail()
        {

        }
        public void Notify()
        {
            var onErrorEvent = new OnErrorEvent(new List<IErrorNotificationParty>() { new ExceptionEmail() });
            onErrorEvent.OnAppException += OnErrorEvent_OnAppException;
        }
        private void OnErrorEvent_OnAppException()
        {
            //send email notification..

        }
    }
}
