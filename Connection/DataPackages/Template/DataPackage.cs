using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages.Template
{
    [Serializable]
    public class DataPackage
    {
        public string Name { get; set; }
        public PacketKind Packet { get; set; }
        public string Data { get; set; }
        public string Params { get; set; }
    }

    public enum PacketKind
    {
        DataExchange,
        DownloadRequest,
        UploadRequest,
        Message,
        BugReport
    }
}
