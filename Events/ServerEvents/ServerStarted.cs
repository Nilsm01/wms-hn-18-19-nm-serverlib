using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ServerEvents
{
    public class ServerStarted
    {
        public static event EventHandler.ServerEventHandler ServerStartedEvent;
        public static void OnServerStarted(Args.ServerEventArgs args)
        {
            if (ServerStartedEvent != null)
            {
                ServerStartedEvent(args);
            }
        }
    }
}
