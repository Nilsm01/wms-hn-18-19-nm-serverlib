using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;

namespace ServerLib.MetaData
{
    class MetaFileManager
    {
        public static List<Template.MetaFile> MetaFiles { get; set; }
        private static int index { get; set; }

        public static void Initialize()
        {
            index = 0;
            MetaFiles = new List<Template.MetaFile>();
            //new Thread(new ThreadStart(getMetaDataFromFiles)).Start();
            getMetaDataFromFiles();
            System.Timers.Timer timer = new System.Timers.Timer(120000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void getMetaDataFromFiles()
        {
            Events.ServerEvents.MetaFileInformation.OnMetaFileInformation(new Events.Args.ServerEventArgs() { Message = "Meta Daten werden geladen..." });
            foreach (string item in Directory.GetFiles(Environment.CurrentDirectory + "\\MetaData"))
            {
                using(StreamReader STR = new StreamReader(item))
                {
                    try
                    {
                        MetaFiles.Add(JsonConvert.DeserializeObject<Template.MetaFile>(STR.ReadLine()));
                    }
                    catch
                    {
                        Events.ServerEvents.MetaFileInformation.OnMetaFileInformation(new Events.Args.ServerEventArgs() { Message = "Fehler beim Laden von Meta Daten, Pfad: " + item });
                    }
                }
            }
            Events.ServerEvents.MetaFileInformation.OnMetaFileInformation(new Events.Args.ServerEventArgs() { Message = "Meta Daten wurden geladen!" });
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteOffRecord();
            Events.ServerEvents.MetaFileInformation.OnMetaFileInformation(new Events.Args.ServerEventArgs() { Message = "Meta-Daten-Liste wurde aktualisiert!" });
        }

        private static void WriteOffRecord()
        {
            //Buffer MetaFile
            Template.MetaFile metaFile;

            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            for (int i = index; i <= index + 50; i++)
            {
                if ((MetaFiles.Count - 1) >= i)
                {
                    metaFile = MetaFiles[i];
                    string data = JsonConvert.SerializeObject(metaFile);
                    using (StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\MetaData\\" + metaFile.Identifier + ".json"))
                    {
                        STW.WriteLine(data);
                    }
                }
                else
                    break;
            }
            if (index >= MetaFiles.Count)
                index = 0;
            else
                index += 50;
        }
    }
}
