using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class DownloadRequest
    {
        public static event EventHandler.DataPackageEventhandler DownloadRequestEvent;
        public static void OnDownloadRequestReceived(Args.DataPackageEventArgs args)
        {
            if (DownloadRequestEvent != null)
            {
                DownloadRequestEvent(args);
            }
        }
    }
}
