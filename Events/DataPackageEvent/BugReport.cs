using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class BugReport
    {
        public static event EventHandler.DataPackageEventhandler BugReportEvent;
        public static void OnBugReportReceived(Args.DataPackageEventArgs args)
        {
            if (BugReportEvent != null)
            {
                BugReportEvent(args);
            }
        }
    }
}
