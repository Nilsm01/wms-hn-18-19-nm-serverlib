using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerLib.MetaData
{
    class MetaFiles
    {
        public static void Create(string FileIdentifier, string FileName, string URL, Template.MetaKategory Kategory)
        {
            Template.MetaFile metaFile = new Template.MetaFile();
            metaFile.Clicked = 0;
            metaFile.Downloaded = 0;
            metaFile.SongName = FileName;
            metaFile.Identifier = FileIdentifier;
            metaFile.Kategory = Kategory;
            metaFile.URL = URL;
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            if(!File.Exists(Environment.CurrentDirectory + "\\MetaData\\" + FileIdentifier + ".json"))
            {
                string data = JsonConvert.SerializeObject(metaFile);
                using(StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\MetaData\\" + FileIdentifier + ".json"))
                {
                    STW.WriteLine(data);
                }
            }
        }
    }
}
