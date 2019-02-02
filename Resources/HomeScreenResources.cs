using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Resources
{
    class HomeScreenResources
    {
        public static string HomeScreenItem1 { get; set; }
        public static string HomeScreenItem2 { get; set; }
        public static string HomeScreenItem3 { get; set; }
        public static string HomeScreenItem4 { get; set; }

        public static string CreateHomeScreenElement(string Identifier, string URL, string FileName)
        {
            return Identifier + ";" + URL + ";" + FileName;
        }
    }
}
