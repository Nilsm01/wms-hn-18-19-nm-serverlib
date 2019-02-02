using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.DataPackageEvent
{
    public class EventHandler
    {
        public delegate void DataPackageEventhandler(Args.DataPackageEventArgs args);
    }
}
