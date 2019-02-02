using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServerLib.Resources;

namespace ServerLib.Connection
{
    class ConnectionHandle
    {
        public static void StartServer()
        {
            try
            {
                ConnectionResources.listener = new TcpListener(IPAddress.Any, 12500);

                Events.ServerEvents.ServerStarted.OnServerStarted(new Events.Args.ServerEventArgs());

                if (!Resources.ConnectionResources.MaintenanceMode)
                {
                    TcpClient client;
                    //Neue Instanz der Klasse Client wird angelegt und initialisiert
                    Client cl = new Client();

                    ConnectionResources.listener.Start();

                    while (ConnectionResources.ServerOn)
                    {
                        client = ConnectionResources.listener.AcceptTcpClient();


                        cl.client = client;
                        cl.Initialize();

                        //Login wird in einem separaten Thread ausgeführt, damit der Verbindungsaufbau anderer Clients nicht behindert wird
                        Thread ClientThread = new Thread(new ThreadStart(delegate () { Handle.Login.HandleClientLogin.HandleLogin(cl); }));
                        ClientThread.IsBackground = true;
                        ClientThread.Start();
                    }
                }
                else
                {
                    MaintenanceMode.Start();
                }
            }
            catch(Exception ex)
            {
                Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs { ErrorMessage = "Fehler beim Starten des Servers oder beim Verbindungsaufbau zu neuen Clients."+ ex.Message + ex.StackTrace});
            }
        }

        public static void StopServer()
        {
            
        }
    }
}
