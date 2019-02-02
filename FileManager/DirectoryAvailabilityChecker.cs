using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerLib.FileManager
{
    class DirectoryAvailabilityChecker
    {
        //Wird immer bei Instanziierung der ServerHandle-Klasse aufgerufen
        public static void CheckDirectories()
        {
            if(!Directory.Exists(Environment.CurrentDirectory + "\\Users"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Users");
            }

            if(!Directory.Exists(Environment.CurrentDirectory + "\\Files"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Files");
            }

            if(!Directory.Exists(Environment.CurrentDirectory + "\\MetaData"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\MetaData");
            }

            if (!Directory.Exists(Environment.CurrentDirectory + "\\UserPofiles"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\UserPofiles");
            }

            if(!Directory.Exists(Environment.CurrentDirectory + "\\SetupFiles"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\SetupFiles");
            }
        }
    }
}
