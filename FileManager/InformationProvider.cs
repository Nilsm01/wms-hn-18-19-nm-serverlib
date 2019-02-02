using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServerLib.FileManager
{
    class InformationProvider
    {
        public static string ListedSongs { get; set; }

        public static void Initialize()
        {
            InitializeUpdateSongList();
        }

        private static void InitializeUpdateSongList()
        {
            //Alle 5 Minuten wird die Liste der Songs aktualisiert
            UpdateSongList();
            Timer timer = new Timer(300000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateSongList();
        }

        private static void UpdateSongList()
        {
            string ReadSongs = string.Empty;
            foreach (string Song in System.IO.Directory.GetFiles(Environment.CurrentDirectory + "\\Files"))
            {
                ReadSongs += System.IO.Path.GetFileNameWithoutExtension(Song) + ":";
            }
            ListedSongs = ReadSongs;
            Events.ServerEvents.SongListUpdated.OnSongListUpdated(new Events.Args.ServerEventArgs());
        }

        public static string[] getAudioFiles()
        {
            DirectoryAvailabilityChecker.CheckDirectories();
            string[] files = System.IO.Directory.GetFiles(Environment.CurrentDirectory + "\\Files");
            string[] songNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                songNames[i] = System.IO.Path.GetFileNameWithoutExtension(files[i]);
            }
            return songNames;
        }
    }
}
