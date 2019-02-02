using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.FileManager
{
    class ErrorHandler
    {
        public static void HandleIOError()
        {
            DirectoryAvailabilityChecker.CheckDirectories();
            FileAvailabilityChecker.CheckFiles();
        }
    }
}
