using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ErrorEvents
{
    public class NetworkStreamError
    {
        public static event EventHandler.ErrorEventHandler NetworkStreamErrorEvent;
        public static void OnErrorAppeared(Args.ErrorEventArgs args)
        {
            if (NetworkStreamErrorEvent != null)
            {
                NetworkStreamErrorEvent(args);
            }
        }
    }
}
