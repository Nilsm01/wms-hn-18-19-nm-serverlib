using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ServerEvents
{
    public class MetaFileInformation
    {
        public static event EventHandler.ServerEventHandler MetaFileInformationEvent;
        public static void OnMetaFileInformation(Args.ServerEventArgs args)
        {
            if (MetaFileInformationEvent != null)
            {
                MetaFileInformationEvent(args);
            }
        }
    }
}
