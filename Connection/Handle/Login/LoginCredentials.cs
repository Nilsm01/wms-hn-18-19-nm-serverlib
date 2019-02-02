using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.Login
{
    class LoginCredentials
    {
        public static bool Correct(Client ConnectingClient, Client DummyCredentialClient)
        {
            if(ConnectingClient.Username == DummyCredentialClient.Username && ConnectingClient.Password == DummyCredentialClient.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Client Receive(Client client)
        {
            Client cl = client;
            try
            {

                using (BinaryReader LoginReader = new BinaryReader(client.stream, Encoding.UTF8, true))
                {
                    cl.ConnectionKey = Encoding.ASCII.GetBytes(LoginReader.ReadString());
                    cl.Username = Crypto.Decrypt.String(cl.ConnectionKey, LoginReader.ReadString());
                    cl.Password = Crypto.Decrypt.String(cl.ConnectionKey ,LoginReader.ReadString());
                }

            }
            catch (Exception ex)
            {
                Events.ClientEvents.LoginFailed.OnClientLoginFailed(new Events.Args.ClientEventArgs() { client = client });
                Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Verbindung zum Client bei Login unterbrochen!" + ex.Message + ex.StackTrace });
            }
            return cl;
        }

        public static void SendLsMessage(Client client)
        {
            try
            {
                using (BinaryWriter LoginWriter = new BinaryWriter(client.stream, Encoding.UTF8, true))
                {
                    if (client.LoggedIn)
                    {
                        LoginWriter.Write("login_successful");
                    }
                    else
                    {
                        LoginWriter.Write("login_failed");
                    }
                }
            }
            catch (Exception ex)
            {
                Events.ClientEvents.LoginFailed.OnClientLoginFailed(new Events.Args.ClientEventArgs() { client = client });
                Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Verbindung zum Client bei Login unterbrochen!" + ex.Message + ex.StackTrace });
            }
        }
    }
}
