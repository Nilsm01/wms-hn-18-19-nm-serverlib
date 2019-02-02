using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ServerEvents
{
    public class Maintenance
    {
        public static event EventHandler.ServerEventHandler MaintenanceEvent;
        public static void OnAppear(Args.ServerEventArgs args)
        {
            if (MaintenanceEvent != null)
            {
                MaintenanceEvent(args);
            }
        }
    }
}
