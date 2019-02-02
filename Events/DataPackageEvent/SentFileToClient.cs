using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class SentFileToClient
    {
        public static event EventHandler.DataPackageEventhandler SentFileToClientEvent;
        public static void OnFileSentToClient(Args.DataPackageEventArgs args)
        {
            if (SentFileToClientEvent != null)
            {
                SentFileToClientEvent(args);
            }
        }
    }
}
