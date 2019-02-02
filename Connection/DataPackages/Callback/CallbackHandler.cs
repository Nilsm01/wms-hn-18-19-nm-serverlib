using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages.Callback
{
    class CallbackHandler
    {
        public static void HandleCallbackRequest(DataPackages.Template.DataPackage dataPackage, Client client)
        {
            if (dataPackage.Data == "callback_server")
            {
                if (CallbackDoSProtection.CheckOnCallbackDos(client))
                {
                    Events.DataPackageEvent.Callback.OnCallback(new Events.Args.CallbackEventArgs() { client = client, dataPackage = dataPackage, Message = "Callback von Client " + client.Username + " erhalten" });
                    Resources.XML.SendDataPackage(client, DataPackages.PacketManager.CreatePacket("callback_reply", "NULL", DataPackages.Template.PacketKind.DataExchange));
                }
                else
                {
                    Events.DataPackageEvent.Callback.OnCallback(new Events.Args.CallbackEventArgs() { client = client, dataPackage = dataPackage, Message = "[Warnung] Callback von Client " + client.Username + " geblockt!" });
                }
                client.RequestedCallbacks.Add(new Template.Callback() { TimeStamp = DateTime.Now, Username = client.Username });
            }
            else if (dataPackage.Data == "callback_reply")
            {
                Events.DataPackageEvent.Callback.OnCallback(new Events.Args.CallbackEventArgs() { client = client, dataPackage = dataPackage, Message = "Callback-Bestätigung von " + client.Username + " erhalten." });
            }
        }
    }
}
