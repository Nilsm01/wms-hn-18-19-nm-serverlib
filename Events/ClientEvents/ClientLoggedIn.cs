using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ClientEvents
{
    public class ClientLoggedIn
    {
        public static event EventHandler.ClientEventHandler ClientLoggedInEvent;
        public static void OnClientLoggedIn(Args.ClientEventArgs args)
        {
            if (ClientLoggedInEvent != null)
            {
                ClientLoggedInEvent(args);
            }
        }
    }
}
