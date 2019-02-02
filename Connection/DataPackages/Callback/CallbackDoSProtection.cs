using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages.Callback
{
    class CallbackDoSProtection
    {
        public static bool CheckOnCallbackDos(Client client)
        {
            if (client.RequestedCallbacks.Count == 0)
                return true;

            if (client.UnconformCallbacks <= 15)
            {
                
                int index = client.RequestedCallbacks.Count - 1;

                TimeSpan timeSpan = DateTime.Now - client.RequestedCallbacks[index].TimeStamp;
                if (timeSpan.TotalSeconds <= 10.0D)
                {
                    client.UnconformCallbacks++;
                    return false;
                }
                else
                    return true;
            }
            else
            {
                Events.DataPackageEvent.Callback.OnCallback(new Events.Args.CallbackEventArgs() { client = client, dataPackage = null, Message = "Die Verbindung zu " + client.Username + " wird getrennt wegen Verdacht eines Callback Angriffs!" });
                client.Kick("Callback Spam");
                return false;
            }
        }
    }
}
