using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.MetaData.Template
{
    public class MetaFile
    {
        public string SongName { get; set; }
        public string Identifier { get; set; }
        public string URL { get; set; }
        public MetaKategory Kategory { get; set; }
        public int Clicked { get; set; }
        public int Downloaded { get; set; }
    }

    public enum MetaKategory
    {
        Pop,
        Rap,
        HipHop,
        House,
        DeepHouse,
        Techno,
        Dubstep,
        NotDefined
    }
}
