using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.FileManager
{
    class UserFiles
    {
        public static bool CheckUser(Connection.Client client)
        {
            if(File.Exists(Environment.CurrentDirectory + "\\Users\\" + client.Username))
            {
                StreamReader STR = new StreamReader(Environment.CurrentDirectory + "\\Users\\" + client.Username);
                string Password = STR.ReadLine();
                if(Password == client.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
