using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerLib.Resources
{
    class XML
    {
        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }

        public static void SendDataPackage(Connection.Client client, Connection.DataPackages.Template.DataPackage dataPacket)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Connection.DataPackages.Template.DataPackage));
                if (client.stream.CanWrite)
                {
                    xmlSerializer.Serialize(client.stream, dataPacket);
                }
                else
                {
                    Events.ErrorEvents.NetworkStreamError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "In den NetworkStream des Clients mit dem Nutzernamen: " + client.Username + " kann nicht geschrieben werden! Datenpacket nicht gesendet!" });
                }
            }
            catch
            {
                Events.ErrorEvents.ConnectionError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Fehler beim Senden eines Datenpackets an Client: " + client.Username + "!" });
            }
        }
    }
}
