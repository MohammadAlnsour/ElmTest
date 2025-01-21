using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTest.Shared.AppExceptions.ExpNotParties
{
    public class ExceptionSqlDb : IErrorNotificationParty
    {
        public void Notify()
        {
            var onErrorEvent = new OnErrorEvent(new List<IErrorNotificationParty>() { new ExceptionSqlDb() });
            onErrorEvent.OnAppException += OnErrorEvent_OnAppException;
        }

        private void OnErrorEvent_OnAppException()
        {
           //store execption in db.
        }
    }
}
