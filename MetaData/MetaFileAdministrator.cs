using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.MetaData
{
    public class MetaFileAdministrator
    {
        public static void CreateMetaFilesFromSongFiles()
        {
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            foreach (string item in Directory.GetFiles(Environment.CurrentDirectory + "\\Files"))
            {
                string Name = Path.GetFileNameWithoutExtension(item);
                if (!File.Exists(Environment.CurrentDirectory + "\\MetaData\\" + Name + ".json"))
                    MetaFiles.Create(Name, Name, "https://greeneyedmedia.com/wp-content/plugins/woocommerce/assets/images/placeholder.png", Template.MetaKategory.NotDefined);
            }
            Events.ServerEvents.MetaFileInformation.OnMetaFileInformation(new Events.Args.ServerEventArgs() { Message = "Meta Daten wurden für Songs generiert!" });
        }

        public static void ClickCounterUp(string FileName)
        {
            try
            {
                MetaFileManager.MetaFiles.Where(i => i.SongName == FileName).FirstOrDefault().Clicked++;
            }
            catch
            {
                Events.ServerEvents.MetaFileInformation.OnMetaFileInformation(new Events.Args.ServerEventArgs() { Message = "Fehler beim erhöhen der Clicks einer Meta-Datei! {" + FileName + "}" });
            }
        }

        public static Template.MetaFile getMetaDataFromFileName(string FileName)
        {
            if(File.Exists(Environment.CurrentDirectory + "\\MetaData\\" + FileName + ".json"))
            {
                Template.MetaFile metaFile;
                using (StreamReader STR = new StreamReader(Environment.CurrentDirectory + "\\MetaData\\" + FileName + ".json"))
                {
                    metaFile = Newtonsoft.Json.JsonConvert.DeserializeObject<Template.MetaFile>(STR.ReadLine());
                }
                return metaFile;
            }
            else
            {
                return null;
            }
        }
    }
}
