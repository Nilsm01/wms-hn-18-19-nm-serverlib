using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ServerEvents
{
    public class EventHandler
    {
        public delegate void ServerEventHandler(Args.ServerEventArgs args);
    }
}
