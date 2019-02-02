using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerLib.Connection.Handle.Download
{
    class ClientInterface
    {
        public static void ProvideDownload(DownloadRequest downloadRequest)
        {
            string Path = Environment.CurrentDirectory + "\\Files\\" + downloadRequest.FileName + ".mp3";
            if (File.Exists(Path))
            {
                try
                {
                    FileInfo info = new FileInfo(Path);
                    //Nachricht an Client, dass die Datei jetzt gesendet wird
                    Resources.XML.SendDataPackage(downloadRequest.client, new DataPackages.Template.DataPackage()
                    {
                        Data = "song_incoming",
                        Name = DataPackages.PackageAdministrator.GetPacketName(DataPackages.Template.PacketKind.DataExchange),
                        Packet = DataPackages.Template.PacketKind.DataExchange,
                        Params = downloadRequest.FileName + ":" + info.Length.ToString()
                    });

                    using (var output = File.OpenRead(Path))
                    {
                        var buffer = new byte[4096];
                        int bytesRead;
                        //Datei wird ausgelesen und ausgelsener 4KB block wird in Buffer geschrieben
                        while ((bytesRead = output.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //Buffer wird verschlüsselt
                            //buffer = Crypto.Encrypt.Byte(buffer, downloadRequest.client.ConnectionKey);
                            //Buffer wird in den Stream geschrieben
                            downloadRequest.client.stream.Write(buffer, 0, bytesRead);
                        }
                    }
                    Events.DataPackageEvent.SentFileToClient.OnFileSentToClient(new Events.Args.DataPackageEventArgs() { client = downloadRequest.client, dataPackage = downloadRequest.dataPackage });
                    MetaData.MetaFileManager.MetaFiles.Where(i => i.SongName == downloadRequest.FileName).FirstOrDefault().Downloaded++;
                }
                catch
                {
                    Events.ErrorEvents.DownloadError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Fehler beim bereitstellen der Datei: " + downloadRequest.FileName + " für den Client: " + downloadRequest.client.Username });
                }
            }
            else
            {
                Resources.XML.SendDataPackage(downloadRequest.client, new DataPackages.Template.DataPackage()
                {
                    Data = "song_not_found",
                    Name = DataPackages.PackageAdministrator.GetPacketName(Connection.DataPackages.Template.PacketKind.DataExchange),
                    Packet = DataPackages.Template.PacketKind.DataExchange,
                    Params = downloadRequest.FileName
                });
                Events.ErrorEvents.DownloadError.OnErrorAppeared(new Events.Args.ErrorEventArgs() { ErrorMessage = "Fehler beim bereitstellen der Datei: " + downloadRequest.FileName + " für den Client: " + downloadRequest.client.Username + ". Die Audiodatei konnte nicht gefunden werden!" });
            }
        }
    }
}
