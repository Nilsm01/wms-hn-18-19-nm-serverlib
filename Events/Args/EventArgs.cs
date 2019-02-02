using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.Args
{
    public class ErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
    }

    public class ClientEventArgs : EventArgs
    {
        public Connection.Client client { get; set; }
    }

    public class DataPackageEventArgs : EventArgs
    {
        public Connection.DataPackages.Template.DataPackage dataPackage { get; set; }
        public Connection.Client client { get; set; }
    }

    public class ServerEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class CallbackEventArgs : EventArgs
    {
        public string Message { get; set; }
        public Connection.DataPackages.Template.DataPackage dataPackage { get; set; }
        public Connection.Client client { get; set; }
    }
}
