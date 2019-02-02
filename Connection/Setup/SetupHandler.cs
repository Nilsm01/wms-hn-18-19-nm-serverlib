using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Setup
{
    class SetupHandler
    {
        public static void ProvideSetup(Client client)
        {
            BinaryReader reader = new BinaryReader(client.stream);
            string received = string.Empty;
            while (true)
            {
                received = reader.ReadString();
                if(received == "EXE_FILE")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\ClientUI.exe", client);
                }
                else if(received == "METRO_FRAMEWORK:1")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\MetroFramework.dll", client);
                }
                else if(received == "METRO_FRAMEWORK:2")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\MetroFramework.Design.dll", client);
                }
                else if (received == "METRO_FRAMEWORK:3")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\MetroFramework.Fonts.dll", client);
                }
                else if (received == "NEWTONSOFT")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\Newtonsoft.Json.dll", client);
                }
                else if (received == "CLIENTLIB")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\ClientLib.dll", client);
                }
                else if (received == "AXINTEROP.WMPLiIB")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\AxInterop.WMPLib.dll", client);
                }
                else if (received == "INTEROP.WMPLIB")
                {
                    SendFile(Environment.CurrentDirectory + "\\SetupFiles\\Interop.WMPLib.dll", client);
                }
                else if(received == "DOWNLOAD_COMPLETED")
                {
                    break;
                }
            }
            reader.Close();
        }

        private static void SendFile(string path, Client client)
        {
            FileInfo fileInfo = new FileInfo(path);
            using(BinaryWriter writer = new BinaryWriter(client.stream, Encoding.UTF8, true))
            {
                writer.Write(Path.GetFileName(path) + ":" + fileInfo.Length);
            }

            using (var output = File.OpenRead(path))
            {
                var buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = output.Read(buffer, 0, buffer.Length)) > 0)
                {
                    client.stream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
