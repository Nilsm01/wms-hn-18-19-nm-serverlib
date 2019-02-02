using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages
{
    class PackageAdministrator
    {
        private static int PacketCounter { get; set; }


        public static string GetPacketName(DataPackages.Template.DataPackage dataPackage)
        {
            if (dataPackage.Packet == Template.PacketKind.DataExchange)
                return "SV:DATEX.PACK_" + PacketCounter;
            else if(dataPackage.Packet == Template.PacketKind.DownloadRequest)
                return "SV:DLREQ.PACK_" + PacketCounter;
            else if (dataPackage.Packet == Template.PacketKind.Message)
                return "SV:MSG.PACK_" + PacketCounter;
            else if (dataPackage.Packet == Template.PacketKind.UploadRequest)
                return "SV:ULREQ.PACK_" + PacketCounter;
            else if (dataPackage.Packet == Template.PacketKind.BugReport)
                return "SV:BGRP.PACK_" + PacketCounter;

            PacketCounter++;
            return "SV:UNINITIALIZED.PACK_" + PacketCounter;
        }

        public static string GetPacketName(DataPackages.Template.PacketKind packetKind)
        {
            if (packetKind == Template.PacketKind.DataExchange)
                return "SV:DATEX.PACK_" + PacketCounter;
            else if (packetKind == Template.PacketKind.DownloadRequest)
                return "SV:DLREQ.PACK_" + PacketCounter;
            else if (packetKind == Template.PacketKind.Message)
                return "SV:MSG.PACK_" + PacketCounter;
            else if (packetKind == Template.PacketKind.UploadRequest)
                return "SV:ULREQ.PACK_" + PacketCounter;
            else if (packetKind == Template.PacketKind.BugReport)
                return "SV:BGRP.PACK_" + PacketCounter;

            PacketCounter++;
            return "SV:UNINITIALIZED.PACK_" + PacketCounter;
        }

        public static void PacketReceived(Template.DataPackage dataPackage, Client client)
        {
            PacketCounter++;
            //Statistische Auswertung der Datenpakete
        }
    }
}
