using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.CommandResponder
{
    class HomeScreen
    {
        public static void Send(Client client)
        {
            string HomeScreenData = Resources.HomeScreenResources.HomeScreenItem1 + "|" +
                                    Resources.HomeScreenResources.HomeScreenItem2 + "|" +
                                    Resources.HomeScreenResources.HomeScreenItem3 + "|" +
                                    Resources.HomeScreenResources.HomeScreenItem4;

            Resources.XML.SendDataPackage(client, DataPackages.PacketManager.CreatePacket("home_screen:reply", HomeScreenData, DataPackages.Template.PacketKind.DataExchange));
        }
    }
}
