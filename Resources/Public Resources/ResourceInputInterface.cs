using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Resources.Public_Resources
{
    public class ResourceInputInteface
    {
        public static void SetStaticItems(string FileName1, string FileName2, string FileName3, string FileName4)
        {
            MetaData.Template.MetaFile metaData1 = MetaData.MetaFileAdministrator.getMetaDataFromFileName(FileName1);
            MetaData.Template.MetaFile metaData2 = MetaData.MetaFileAdministrator.getMetaDataFromFileName(FileName2);
            MetaData.Template.MetaFile metaData3 = MetaData.MetaFileAdministrator.getMetaDataFromFileName(FileName3);
            MetaData.Template.MetaFile metaData4 = MetaData.MetaFileAdministrator.getMetaDataFromFileName(FileName4);

            if (metaData1 != null)
                HomeScreenResources.HomeScreenItem1 = HomeScreenResources.CreateHomeScreenElement(metaData1.Identifier, metaData1.URL, metaData1.SongName);
            else
                HomeScreenResources.HomeScreenItem1 = HomeScreenResources.CreateHomeScreenElement("Fehler", "Error", "Fehler");
            if (metaData2 != null)
                HomeScreenResources.HomeScreenItem2 = HomeScreenResources.CreateHomeScreenElement(metaData2.Identifier, metaData2.URL, metaData2.SongName);
            else
                HomeScreenResources.HomeScreenItem1 = HomeScreenResources.CreateHomeScreenElement("Fehler", "Error", "Fehler");
            if (metaData3 != null)
                HomeScreenResources.HomeScreenItem3 = HomeScreenResources.CreateHomeScreenElement(metaData3.Identifier, metaData3.URL, metaData3.SongName);
            else
                HomeScreenResources.HomeScreenItem1 = HomeScreenResources.CreateHomeScreenElement("Fehler", "Error", "Fehler");
            if (metaData4 != null)
                HomeScreenResources.HomeScreenItem4 = HomeScreenResources.CreateHomeScreenElement(metaData4.Identifier, metaData4.URL, metaData4.SongName);
            else
                HomeScreenResources.HomeScreenItem1 = HomeScreenResources.CreateHomeScreenElement("Fehler", "Error", "Fehler");
        }
    }
}
