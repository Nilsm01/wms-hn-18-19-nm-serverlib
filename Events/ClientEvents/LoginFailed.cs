using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ClientEvents
{
    public class LoginFailed
    {
        public static event EventHandler.ClientEventHandler ClientLoginFailedEvent;
        public static void OnClientLoginFailed(Args.ClientEventArgs args)
        {
            args.client.DisconnectClient();
            if (ClientLoginFailedEvent != null)
            {
                ClientLoginFailedEvent(args);
            }
        }
    }
}
