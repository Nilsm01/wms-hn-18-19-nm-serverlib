using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ClientEvents
{
    public class PackageReceived
    {
        public static event EventHandler.ClientEventHandler ClientPackageReceived;
        public static void OnClientPackageReceived(Args.ClientEventArgs args)
        {
            if (ClientPackageReceived != null)
            {
                ClientPackageReceived(args);
            }
        }
    }
}
