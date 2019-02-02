using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.FileManager
{
    class FileAvailabilityChecker
    {
        //Wird immer bei Instanziierung der ServerHandle-Klasse aufgerufen
        public static void CheckFiles()
        {
            
        }

        public static void CreateSetupFile()
        {
            using (StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\setup.cmd"))
            {
                STW.WriteLine("xcopy \"" + Environment.CurrentDirectory + "\" \"" + Environment.CurrentDirectory + "\\SetupFiles\\" + "\"");
                STW.Close();
            }
        }
    }
}
