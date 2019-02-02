using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Resources
{
    class ConnectionResources
    {
        public static TcpListener listener { get; set; }
        public static bool ServerOn { get; set; }
        public static List<Connection.Client> ConnectedClients { get; set; }
        public static bool MaintenanceMode { get; set; }
    }
}
