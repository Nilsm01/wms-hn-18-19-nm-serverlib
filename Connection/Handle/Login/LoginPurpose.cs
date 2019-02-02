using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Handle.Login
{
    class LoginPurpose
    {
        public static LoginPurposes Check(Client client)
        {
            string puropse = string.Empty;
            using (BinaryReader reader = new BinaryReader(client.stream, Encoding.UTF8, true))
            {
                puropse = reader.ReadString();
            }
            if(puropse == "LogIn")
            {
                return LoginPurposes.ClientLogIn;
            }
            else if(puropse == "DownloadSetup")
            {
                return LoginPurposes.DownloadSetup;
            }
            else
            {
                return LoginPurposes.None;
            }
        }

        public enum LoginPurposes
        {
            ClientLogIn,
            DownloadSetup,
            None
        }
    }
}
