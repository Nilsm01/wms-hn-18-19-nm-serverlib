using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ClientEvents
{
    public class EventHandler
    {
        public delegate void ClientEventHandler(Args.ClientEventArgs args);
    }
}
