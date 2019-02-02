using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.Login
{
    class HandleClientLogin
    {
        public static void HandleLogin(Client client)
        {
            try
            {
                LoginPurpose.LoginPurposes loginPurpose = LoginPurpose.Check(client);
                if (loginPurpose == LoginPurpose.LoginPurposes.ClientLogIn)
                {
                    client = LoginCredentials.Receive(client);
                    if (client != null)
                    {
                        if (FileManager.UserFiles.CheckUser(client))
                        {
                            ClientRank rank = Rank.GetUserRank(client);
                            if (rank != 0)
                            {
                                client.UserRank = rank;
                                Resources.ConnectionResources.ConnectedClients.Add(client);
                                client.LoggedIn = true;
                                client.IsConnected = true;
                                LoginCredentials.SendLsMessage(client);
                                TrafficHandler.HandleClient(client);
                            }
                            else
                            {
                                client.LoggedIn = false;
                                Events.ClientEvents.LoginFailed.OnClientLoginFailed(new Events.Args.ClientEventArgs() { client = client });
                                LoginCredentials.SendLsMessage(client);
                                Console.WriteLine("Rang nicht gefunden!");
                            }
                        }
                        else
                        {
                            client.LoggedIn = false;
                            //Send Login failed response
                            LoginCredentials.SendLsMessage(client);
                            Events.ClientEvents.LoginFailed.OnClientLoginFailed(new Events.Args.ClientEventArgs() { client = client });
                        }
                    }
                    else
                    {
                        client.LoggedIn = false;
                        Console.WriteLine("False Login");
                        LoginCredentials.SendLsMessage(client);
                    }
                }
                else if(loginPurpose == LoginPurpose.LoginPurposes.DownloadSetup)
                {
                    Setup.SetupHandler.ProvideSetup(client);
                }
                /*
                else if(loginPurpose == LoginPurpose.LoginPurposes.None)
                {

                }
                else
                {

                }
                */
            }
            catch
            {
                Events.ClientEvents.LoginFailed.OnClientLoginFailed(new Events.Args.ClientEventArgs() { client = client });
            }
        }
    }
}
