using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Connection.DataPackages
{
    class PacketManager
    {
        public static Template.DataPackage CreatePacket(string Data, string Parameter, DataPackages.Template.PacketKind packetKind)
        {
            Template.DataPackage dataPacket = new Template.DataPackage();
            dataPacket.Data = Data;
            dataPacket.Params = Parameter;
            dataPacket.Packet = packetKind;
            dataPacket.Name = PackageAdministrator.GetPacketName(dataPacket);
            return dataPacket;
        }

        public static void ClearPacket(Template.DataPackage dataPacket)
        {
            dataPacket.Name = string.Empty;
            dataPacket.Data = string.Empty;
            dataPacket.Packet = 0;
            dataPacket.Params = string.Empty;
        }

        public static Template.DataPackage EncryptDataPackage(Template.DataPackage dataPackage, byte[] CryptoKey)
        {
            return CreatePacket(Crypto.Encrypt.String(CryptoKey, dataPackage.Data), Crypto.Encrypt.String(CryptoKey, dataPackage.Params), dataPackage.Packet);
        }

        public static Template.DataPackage DecryptDataPackage(Template.DataPackage dataPackage, byte[] CryptoKey)
        {
            Template.DataPackage decryptedDataPackage = new Template.DataPackage()
            {
                Data = Crypto.Decrypt.String(CryptoKey, dataPackage.Data),
                Params = Crypto.Decrypt.String(CryptoKey, dataPackage.Params),
                Name = dataPackage.Name,
                Packet = dataPackage.Packet
            };
            return decryptedDataPackage;
        }
    }
}
