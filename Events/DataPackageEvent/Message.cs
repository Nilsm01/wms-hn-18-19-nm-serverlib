using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class Message
    {
        public static event EventHandler.DataPackageEventhandler MessageEvent;
        public static void OnMessageReceived(Args.DataPackageEventArgs args)
        {
            if (MessageEvent != null)
            {
                MessageEvent(args);
            }
        }
    }
}
