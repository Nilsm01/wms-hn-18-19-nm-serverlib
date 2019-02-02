using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ClientEvents
{
    public class ClientDisconnected
    {
        public static event EventHandler.ClientEventHandler ClientDisconnectedEvent;
        public static void OnClientDisconnected(Args.ClientEventArgs args)
        {
            if (ClientDisconnectedEvent != null)
            {
                ClientDisconnectedEvent(args);
            }
        }
    }
}
