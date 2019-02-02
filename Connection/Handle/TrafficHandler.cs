using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle
{
    class TrafficHandler
    {
        public static void HandleClient(Client client)
        {
            //Das OnClientLoggedIn Event wird ausgelöst, d.h. ein neuer Client hat sich verbunden
            Events.ClientEvents.ClientLoggedIn.OnClientLoggedIn(new Events.Args.ClientEventArgs() { client = client });

            //Das lokale Datenpacket in das alle eingehenden Datenpakete geschrieben werden
            DataPackages.Template.DataPackage dataPacket = new DataPackages.Template.DataPackage();
            //Buffer für den NetworkStream
            byte[] data = new byte[4096]; // 4KB Buffer => Datenpackete die von Clients gesendet werden dürfen nicht < 4KB sein, ansonsten wird die Verbindung zu diesen Clients getrennt
            while (true)
            {
                try
                {
                    //Daten werden von NetworkStream gelesen und sind in Bytes Codiert
                    client.stream.Read(data, 0, data.Length);

                    //Decodierung aus den Bytes zu einem String, der String enthält XML-Code 
                    string Datstr = ASCIIEncoding.ASCII.GetString(data);
                    //Der im String enthaltene XML Code wird zu einem Connection.DataPackages.Template.DataPackage Objekt deserialisiert und ist damit ein lesbares Datenpacket
                    dataPacket = Resources.XML.DeserializeFromXml<DataPackages.Template.DataPackage>(Datstr);
                    //Das Datenpacket wird ausgewertet
                    DataPackages.EvaluatePackage.RaiseHandleEvent(dataPacket, client);

                    //Der Buffer des NetworkStreams wird zurückgesetzt
                    Array.Clear(data, 0, data.Length);
                    //Das Datenpacket wird zurückgesetzt, damit es neu beschrieben werden kann
                    DataPackages.PacketManager.ClearPacket(dataPacket);
                }
                catch (SocketException)
                {
                    //Disconnect des Clients ausführen
                    client.DisconnectClient();
                    break;
                }
                catch(System.IO.IOException)
                {
                    //Disconnect des Clients ausführen
                    client.DisconnectClient();
                    break;
                }
                catch
                {
                    //Bei Fehlern, verlorener Verbindung etc. wird die Verbindung zum Client am Socket korrekt getrennt und der Client wird als Offline registriert
                    Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Fehler beim Empfangen eines Datenpackets, die Verbindung zum Client wird getrennt!" });
                    client.DisconnectClient();
                    break;
                }
            }
        }
    }
}
