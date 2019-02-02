using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages
{
    class PackageNameAdministrator
    {
        private static int PacketCounter { get; set; }


        public static string GetPacketName()
        {
            PacketCounter++;
            return "SV:DAT.PACK_" + PacketCounter;
        }
    }
}
