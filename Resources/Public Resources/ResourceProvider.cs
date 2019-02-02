using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Resources.Public_Resources
{
    public class ResourceProvider
    {
        public static string[] getAudioFiles()
        {
            return FileManager.InformationProvider.getAudioFiles();
        }
    }
}
