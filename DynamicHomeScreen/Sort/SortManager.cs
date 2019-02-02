using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.DynamicHomeScreen.Sort
{
    class SortManager
    {
        private SortItem[] listItems;
        public SortManager()
        {
            listItems = new SortItem[4];
            for(int i=0; i<4; i++)
            {
                listItems[i] = new SortItem();
            }
        }
        /// <summary>
        /// Überprüft einen Wert auf seine größe und ordnet ihn in an der richtigen Stelle ein
        /// </summary>
        /// <param name="item">Wert der überprüft und eingeordnet werden soll</param>
        public void AddItem(MetaData.Template.MetaFile item)
        {
            if (listItems[0].checkValue(item) != 0) { }
            else if (listItems[1].checkValue(item) != 0) { }
            else if (listItems[2].checkValue(item) != 0) { }
            else if (listItems[3].checkValue(item) != 0) { }
        }
        /// <summary>
        /// Gibt den Wert des angegebenen Indexes zurück
        /// </summary>
        /// <param name="index">Index des erforderlichen Wertes</param>
        /// <returns></returns>
        public MetaData.Template.MetaFile getValue(int index)
        {
            return listItems[index].getValue();
        }
    }
}
