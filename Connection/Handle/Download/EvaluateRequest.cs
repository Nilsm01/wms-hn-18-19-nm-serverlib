using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.Download
{
    class EvaluateRequest
    {
        public static void CreateRequest(Events.Args.DataPackageEventArgs args)
        {
            if (args.client.UserRank == ClientRank.Premium)
            {
                DownloadRequest downloadRequest = new DownloadRequest
                {
                    client = args.client,
                    FileName = args.dataPackage.Data,
                    Name = args.dataPackage.Name,
                    dataPackage = args.dataPackage
                };
                ClientInterface.ProvideDownload(downloadRequest);
            }
            else
            {
                Resources.XML.SendDataPackage(args.client, DataPackages.PacketManager.CreatePacket("permission_error", "Du benötigst Premium um dieses Lied herunterladen zu können!", DataPackages.Template.PacketKind.DataExchange));
            }
        }
    }
}
