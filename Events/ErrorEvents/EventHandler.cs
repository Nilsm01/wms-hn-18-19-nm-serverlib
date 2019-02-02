using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ErrorEvents
{
    public class EventHandler
    {
        public delegate void ErrorEventHandler(Args.ErrorEventArgs args);
    }
}
