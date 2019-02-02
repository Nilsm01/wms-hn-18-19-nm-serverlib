using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection
{

    public class Client
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ClientRank UserRank { get; set; }
        public TcpClient client { get; set; }
        public NetworkStream stream { get; set; }
        public bool LoggedIn { get; set; }
        public bool IsConnected { get; set; }
        public List<DataPackages.Callback.Template.Callback> RequestedCallbacks { get; set; }
        public uint UnconformCallbacks { get; set; }
        public byte[] ConnectionKey { get; set; }
        public void Initialize()
        {
            stream = new NetworkStream(client.Client);
            RequestedCallbacks = new List<DataPackages.Callback.Template.Callback>();
            UnconformCallbacks = 0;
        }
        public void DisconnectClient()
        {
            try
            {
                if (this.IsConnected)
                {
                    this.IsConnected = false;
                    if (Resources.ConnectionResources.ConnectedClients.Contains(this)) { Resources.ConnectionResources.ConnectedClients.Remove(this); }
                    if (client.Connected)
                    {
                        stream.Close();
                        stream.Dispose();
                        client.Close();
                    }
                    client = null;
                    Events.ClientEvents.ClientDisconnected.OnClientDisconnected(new Events.Args.ClientEventArgs() { client = this });
                }
            }
            catch(Exception ex)
            {
                Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Fehler beim Ausführen des Disconnects von einem Client." + ex.Message + ex.StackTrace});
            }
        }
        public void Kick(string Reason)
        {
            Resources.XML.SendDataPackage(this, DataPackages.PacketManager.CreatePacket("server_kick", Reason, DataPackages.Template.PacketKind.DataExchange));
            DisconnectClient();
        }
    }
}
