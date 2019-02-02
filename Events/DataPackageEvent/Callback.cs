using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class Callback
    {
        public delegate void CallbackEventHandler(Args.CallbackEventArgs args);
        public static event CallbackEventHandler CallbackEvent;
        public static void OnCallback(Args.CallbackEventArgs args)
        {
            if (CallbackEvent != null)
            {
                CallbackEvent(args);
            }
        }
    }
}
