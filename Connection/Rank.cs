using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection
{
    class Rank
    {
        public static Connection.ClientRank GetUserRank(Connection.Client client)
        {
            if (File.Exists(Environment.CurrentDirectory + "\\Users\\" + client.Username))
            {
                try
                {
                    StreamReader STR = new StreamReader(Environment.CurrentDirectory + "\\Users\\" + client.Username);
                    STR.ReadLine();
                    int Rank = Int32.Parse(STR.ReadLine());
                    STR.Close();
                    Connection.ClientRank clientRank = (Connection.ClientRank)Rank;
                    return clientRank;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    public enum ClientRank
    {
        Artist,
        Premium,
        User
    }
}
