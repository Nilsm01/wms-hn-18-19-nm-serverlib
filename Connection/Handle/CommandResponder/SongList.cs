using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.CommandResponder
{
    class SongList
    {
        public static void Send(Client clien)
        {
            DataPackages.Template.DataPackage dataPackage = new DataPackages.Template.DataPackage();
            dataPackage.Data = "song_list";
            dataPackage.Packet = DataPackages.Template.PacketKind.DataExchange;
            dataPackage.Params = FileManager.InformationProvider.ListedSongs;
            dataPackage.Name = DataPackages.PackageAdministrator.GetPacketName(dataPackage);
            Resources.XML.SendDataPackage(clien, dataPackage);
        }
    }
}
