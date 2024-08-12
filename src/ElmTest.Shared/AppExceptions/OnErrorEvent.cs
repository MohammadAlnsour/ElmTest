namespace ElmTest.Shared.AppExceptions
{
    public class OnErrorEvent
    {
        private readonly IEnumerable<IErrorNotificationParty> _errorNotificationParty;

        public OnErrorEvent(IEnumerable<IErrorNotificationParty> errorNotificationParty)
        {
            _errorNotificationParty = errorNotificationParty;
        }
        public event Action OnAppException;
        public void AppExecptionOccured()
        {
            OnAppException?.Invoke();
            foreach (var party in _errorNotificationParty)
                party.Notify();

        }
    }
}
