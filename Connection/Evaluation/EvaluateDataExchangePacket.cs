using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.Evaluation
{
    class EvaluateDataExchangePacket
    {
        public static void GetCommand(Client client, DataPackages.Template.DataPackage dataPackage)
        {
            try
            {
                if (dataPackage.Data == "send_songs")
                {
                    Handle.CommandResponder.SongList.Send(client);
                }
                else if (dataPackage.Data.Contains("callback"))
                {
                    DataPackages.Callback.CallbackHandler.HandleCallbackRequest(dataPackage, client);
                }
                else if(dataPackage.Data == "send_home_screen")
                {
                    Handle.CommandResponder.HomeScreen.Send(client);
                }
                else if(dataPackage.Data == "song_query:request")
                {
                    string SearchResults = Resources.Services.EvaluateSongQuery(dataPackage.Params);
                    Resources.XML.SendDataPackage(client, DataPackages.PacketManager.CreatePacket("song_query:reply", SearchResults, DataPackages.Template.PacketKind.DataExchange));
                }
                else if(dataPackage.Data == "song_clicked")
                {
                    MetaData.MetaFileAdministrator.ClickCounterUp(dataPackage.Params);
                }
            }
            catch(Exception ex)
            {
                Events.ErrorEvents.EvaluationError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Fehler bei der Auswertung eines DataExchange-Packets." + ex.Message + ex.StackTrace });
            }
        }
    }
}
