using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ErrorEvents
{
    public class IOError
    {
        public static event EventHandler.ErrorEventHandler IOErrorEvent;
        public static void OnErrorAppeared(Args.ErrorEventArgs args)
        {
            if (IOErrorEvent != null)
            {
                IOErrorEvent(args);
            }
        }
    }
}
