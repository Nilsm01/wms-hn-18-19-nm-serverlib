using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ErrorEvents
{
    public class ConnectionError
    {
        public static event EventHandler.ErrorEventHandler ConnectionErrorEvent;
        public static void OnErrorAppeared(Args.ErrorEventArgs args)
        {
            if (ConnectionErrorEvent != null)
            {
                ConnectionErrorEvent(args);
            }
        }
    }
}
