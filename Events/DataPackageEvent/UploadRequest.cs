using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class UploadRequest
    {
        public static event EventHandler.DataPackageEventhandler UploadRequestEvent;
        public static void OnUploadRequestReceived(Args.DataPackageEventArgs args)
        {
            if (UploadRequestEvent != null)
            {
                UploadRequestEvent(args);
            }
        }
    }
}
