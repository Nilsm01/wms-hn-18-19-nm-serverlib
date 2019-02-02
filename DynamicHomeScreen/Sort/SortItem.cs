using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.DynamicHomeScreen.Sort
{
    class SortItem
    {
        private MetaData.Template.MetaFile value;

        public SortItem()
        {
            this.value = new MetaData.Template.MetaFile();
            this.value.Clicked = 0;
        }

        /// <summary>
        /// Überprüft ob der angegebene Wert größer dem alten ist, ersetzt diesen dann und liefert -1 zurück. Ist der neue Wert kleiner als der alte wird 0 zurückgegeben
        /// </summary>
        /// <param name="Value">Neuer Wert</param>
        public int checkValue(MetaData.Template.MetaFile Value)
        {
            if(Value.Clicked > value.Clicked)
            {
                this.value = Value;
                return -1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Gibt den gespeicherten Wert zurück
        /// </summary>
        public MetaData.Template.MetaFile getValue()
        {
            return this.value;
        }
    }
}
