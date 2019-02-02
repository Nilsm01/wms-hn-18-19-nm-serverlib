using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection
{
    public class ResourceProvider
    {
        public static List<Client> GetConnectedClients()
        {
            return Resources.ConnectionResources.ConnectedClients;
        }

        public static bool IsServerOnline()
        {
            return Resources.ConnectionResources.ServerOn;
        }

        public static bool IsMaintenanceModeOn()
        {
            return Resources.ConnectionResources.MaintenanceMode;
        }

        public static void SetMaintenanceMode(bool Mode)
        {
            if(Resources.ConnectionResources.MaintenanceMode && !Mode)
            {
                MaintenanceMode.Stop();
            }
            else
                Resources.ConnectionResources.MaintenanceMode = Mode;
        }
    }
}
