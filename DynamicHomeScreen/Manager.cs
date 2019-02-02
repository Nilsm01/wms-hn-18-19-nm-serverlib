using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.DynamicHomeScreen
{
    class Manager
    {
        public static void Initialize()
        {
            Sort.SortManager sortManager = new Sort.SortManager();
            foreach(MetaData.Template.MetaFile metaFile in MetaData.MetaFileManager.MetaFiles)
            {
                sortManager.AddItem(metaFile);
            }

            MetaData.Template.MetaFile metaFile1, metaFile2, metaFile3, metaFile4;
            metaFile1 = sortManager.getValue(0);
            metaFile2 = sortManager.getValue(1);
            metaFile3 = sortManager.getValue(2);
            metaFile4 = sortManager.getValue(3);
            Resources.HomeScreenResources.HomeScreenItem1 = Resources.HomeScreenResources.CreateHomeScreenElement(metaFile1.Identifier, metaFile1.URL, metaFile1.SongName);
            Resources.HomeScreenResources.HomeScreenItem2 = Resources.HomeScreenResources.CreateHomeScreenElement(metaFile2.Identifier, metaFile2.URL, metaFile2.SongName);
            Resources.HomeScreenResources.HomeScreenItem3 = Resources.HomeScreenResources.CreateHomeScreenElement(metaFile3.Identifier, metaFile3.URL, metaFile3.SongName);
            Resources.HomeScreenResources.HomeScreenItem4 = Resources.HomeScreenResources.CreateHomeScreenElement(metaFile4.Identifier, metaFile4.URL, metaFile4.SongName);
        }
    }
}
