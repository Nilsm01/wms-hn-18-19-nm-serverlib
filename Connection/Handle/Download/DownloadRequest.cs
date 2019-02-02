using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.Download
{
    class DownloadRequest
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public Client client { get; set; }
        public DataPackages.Template.DataPackage dataPackage { get; set; }
        public void Delete()
        {
            this.Name = null;
            this.FileName = null;
            this.dataPackage = null;
        }
    }
}
