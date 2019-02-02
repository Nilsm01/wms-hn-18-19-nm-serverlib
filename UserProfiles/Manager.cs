using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.UserProfiles
{
    class Manager
    {
        public static Template.UserProfile LoadUserProfileByName(string Username)
        {
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            if (File.Exists(FileManager.PathResources.Userprofile + Username + ".json"))
            {
                Template.UserProfile userProfile;
                using (StreamReader STR = new StreamReader(FileManager.PathResources.Userprofile + Username + ".json"))
                {
                    userProfile = Newtonsoft.Json.JsonConvert.DeserializeObject<Template.UserProfile>(STR.ReadLine());
                }
                return userProfile;
            }
            else
                return null;
        }

        public static void CreateUserProfile(string Username)
        {
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            Template.UserProfile userProfile = new Template.UserProfile();
            userProfile.Username = Username;
            using (StreamWriter STW = new StreamWriter(FileManager.PathResources.Userprofile + Username + ".json"))
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(userProfile);
                STW.WriteLine();
            }
        }
    }
}
