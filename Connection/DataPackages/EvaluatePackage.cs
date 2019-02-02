using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages
{
    class EvaluatePackage
    {
        public static void RaiseHandleEvent(DataPackages.Template.DataPackage dataPackage, Client client)
        {
            //Paket wird beim PacketAdministrator registriert
            PackageAdministrator.PacketReceived(dataPackage, client);

            //Event ClientPackageReceived wird getriggert
            Events.ClientEvents.PackageReceived.OnClientPackageReceived(new Events.Args.ClientEventArgs() { client = client });

            if(dataPackage.Packet == Template.PacketKind.DataExchange)
            {
                Evaluation.EvaluateDataExchangePacket.GetCommand(client, dataPackage);
            }
            else if(dataPackage.Packet == Template.PacketKind.DownloadRequest)
            {
                Handle.Download.EvaluateRequest.CreateRequest(new Events.Args.DataPackageEventArgs() { client = client, dataPackage = dataPackage });
                Events.DataPackageEvent.DownloadRequest.OnDownloadRequestReceived(new Events.Args.DataPackageEventArgs() { client = client, dataPackage = dataPackage });
            }
        }
    }
}
