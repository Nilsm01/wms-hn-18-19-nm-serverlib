using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class DataExchange
    {
        public static event EventHandler.DataPackageEventhandler DataExchangeEvent;
        public static void OnDataExchangeReceived(Args.DataPackageEventArgs args)
        {
            if (DataExchangeEvent != null)
            {
                DataExchangeEvent(args);
            }
        }
    }
}
