using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Client
{
    internal static class MyClient
    {
        private static TcpClient Client { get; set; }
        private static BinaryWriter binaryWriter { get; set; }
        private static BinaryReader binaryReader { get; set; }
        static MyClient()
        {
            var ip = IPAddress.Parse("127.0.0.1");
            var port = 27001;

            Client = new TcpClient(ip.ToString(), port);
            binaryWriter = new BinaryWriter(Client.GetStream());
            binaryReader = new BinaryReader(Client.GetStream());
        }

        public static void SendCommandToServer(Command command)
        {
            Task.Run(() =>
            {
                // Convert MyClass to byte array
                byte[] serializedObject = Serializer.SerializeObject(command);

                // Compress the byte array using GZip
                byte[] compressedObject = Compressor.Compress(serializedObject);

                binaryWriter.Write(compressedObject);
            });
        }
        
        

    }
}
