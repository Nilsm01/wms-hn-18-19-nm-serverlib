using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace ServerLib.Connection
{
    public class MaintenanceMode
    {
        public static void Start()
        {
            TcpClient client;
            //Neue Instanz der Klasse Client wird angelegt und initialisiert
            Events.ServerEvents.Maintenance.OnAppear(new Events.Args.ServerEventArgs() { Message = "Wartungsmodus ist aktiviert" });
            Resources.ConnectionResources.listener.Start();

            while (Resources.ConnectionResources.ServerOn)
            {
                try
                {
                    client = Resources.ConnectionResources.listener.AcceptTcpClient();

                    Events.ServerEvents.Maintenance.OnAppear(new Events.Args.ServerEventArgs() { Message = "Ein verbindender Client wurde getrennt" });

                    using (BinaryReader reader = new BinaryReader(client.GetStream(), Encoding.UTF8, true))
                    {
                        reader.ReadString();
                        reader.ReadString();
                    }

                    using (BinaryWriter reader = new BinaryWriter(client.GetStream(), Encoding.UTF8, false))
                    {
                        reader.Write("server_maintenance");
                    }
                    client.Close();
                    client = null;
                }
                catch
                {
                    Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs { ErrorMessage = "Fehler beim bearbeiten von Clients im Wartungsmodus!"});
                }
            }
            
        }

        public static void Stop()
        {
            Resources.ConnectionResources.MaintenanceMode = false;
            Resources.ConnectionResources.ServerOn = false;
            Resources.ConnectionResources.listener.Stop();
            Resources.ConnectionResources.ServerOn = true;
            ConnectionHandle.StartServer();
        }
    }
}
