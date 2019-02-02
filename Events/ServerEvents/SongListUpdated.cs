using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Events.ServerEvents
{
    public class SongListUpdated
    {
        public static event EventHandler.ServerEventHandler SongListUpdatedEvent;
        public static void OnSongListUpdated(Args.ServerEventArgs args)
        {
            if (SongListUpdatedEvent != null)
            {
                SongListUpdatedEvent(args);
            }
        }
    }
}
