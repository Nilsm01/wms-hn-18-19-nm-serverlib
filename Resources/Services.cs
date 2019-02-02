using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Resources
{
    class Services
    {
        public static void initialize()
        {
            ConnectionResources.ConnectedClients = new List<Connection.Client>();
            FileManager.InformationProvider.Initialize();
        }

        public static string EvaluateSongQuery(string search)
        {
            string searchResults = string.Empty;
            foreach(string item in FileManager.InformationProvider.ListedSongs.Split(':'))
            {
                if (item.Contains(search))
                    searchResults += item + ":";
            }
            return searchResults;
        }

        public static void ProvideSetupFiles()
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\setup.cmd");
        }
    }
}
