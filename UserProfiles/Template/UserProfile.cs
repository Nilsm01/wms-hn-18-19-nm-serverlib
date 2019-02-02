using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.UserProfiles.Template
{
    class UserProfile
    {
        public List<String> SearchQueries = new List<string>();
        public string Username;
        public void SaveUserProfile()
        {
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            using (StreamWriter STW = new StreamWriter(FileManager.PathResources.Userprofile + this.Username + ".json"))
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                STW.WriteLine(data);
            }
        }
    }
}
