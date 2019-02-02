using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib
{
    public class ServerHandle
    {
        public static bool LogDataPackets;
        /// <summary>
        /// Startet den Server
        /// </summary>
        /// <param name="DynamicHomeScreenEnabled">Gibt an ob ein dynamischer oder ein statischer Home Screen verwendet wird</param>
        public static void StartServer(bool DynamicHomeScreenEnabled)
        {       
            //Status des Server auf "ON" setzen
            Resources.ConnectionResources.ServerOn = true;

            //Alle zur Laufzeit benötigten Verzeichnise auf Existenz überprüfen und im Fall der Nichtexistenz erstellen
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            //Alle zur Laufzeit benötigten Dateien auf Existenz überprüfen und im Fall der Nichtexistenz erstellen
            FileManager.FileAvailabilityChecker.CheckFiles();

            //Alle Services initialisieren
            Resources.Services.initialize();

            //Alle fehlenden Meta Daten werden automatisch generiert
            new Thread(new ThreadStart(MetaData.MetaFileAdministrator.CreateMetaFilesFromSongFiles)).Start();

            //Die Metadaten zu allen Songs werden geladen und die Aktualisierungsroutine wird aktiviert
            MetaData.MetaFileManager.Initialize();

            //Es wird überprüft ob ein statischer oder ein dynamischer Home Screen verwendet werden soll
            if (DynamicHomeScreenEnabled)
            {
                DynamicHomeScreen.Manager.Initialize();
            }

            //Thread zum Verbinden der Clients wird deklariert, initialisiert und gestartet
            Thread ListenerThread = new Thread(new ThreadStart(Connection.ConnectionHandle.StartServer));
            ListenerThread.IsBackground = true;
            ListenerThread.Start();
        }

    }
}
