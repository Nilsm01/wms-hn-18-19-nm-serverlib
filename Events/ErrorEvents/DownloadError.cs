using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ErrorEvents
{
    public class DownloadError
    {
        public static event EventHandler.ErrorEventHandler DownloadErrorEvent;
        public static void OnErrorAppeared(Args.ErrorEventArgs args)
        {
            if (DownloadErrorEvent != null)
            {
                DownloadErrorEvent(args);
            }
        }
    }
}
