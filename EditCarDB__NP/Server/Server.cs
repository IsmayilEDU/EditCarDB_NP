
using Bogus;
using Models;
using Server;
using System.Net;
using System.Net.Sockets;

#pragma warning disable
var carFaker = new Faker<Car>()
    .RuleFor(c => c.Id, f => f.IndexFaker)
    .RuleFor(c => c.Make, f => f.Vehicle.Manufacturer())
    .RuleFor(c => c.Model, f => f.Vehicle.Model())
    .RuleFor(c => c.Year, f => f.Random.Short(2000, 2023))
    .RuleFor(c => c.Color, f => f.Commerce.Color());
var fakeCars = carFaker.Generate(200);

var ip = IPAddress.Parse("127.0.0.1");
var port = 27001;


var listener = new TcpListener(ip, port);
listener.Start(15);


while (true)
{
    var client = listener.AcceptTcpClient();

    Task.Run(() =>
    {
        var clientStream = client.GetStream();

        var binaryReader = new BinaryReader(clientStream);

        byte[] CommandObjectBytes;

        while (true)
        {
            var len = (int)clientStream.Length;
            CommandObjectBytes = binaryReader.ReadBytes(len);
            byte[] decompressedObject = Compressor.Decompress(CommandObjectBytes);
            Command command = (Command)Serializer.DeserializeObject(decompressedObject);

            string type = command.Method.ToString();
            if (type == HTTPS.ADD.ToString())
            {
                MyDatabase.Add(command.car);
            }
            else if (type == HTTPS.GET.ToString())
            {
                var WantedCar = MyDatabase.GetById(command.car.Id);
                SendObjectToClient(WantedCar, clientStream);
            }
            else if (type == HTTPS.GETALL.ToString())
            {
                var allCars = MyDatabase.GetAll();
                SendObjectToClient(allCars, clientStream);
            }
            else if (type == HTTPS.UPDATE.ToString())
            {
                MyDatabase.Update(command.car);
            }
            else if (type == HTTPS.DELETE.ToString())
            {
                MyDatabase.Delete(command.car.Id);
            }


        }

    });

}

void SendObjectToClient(object obj, NetworkStream? networkStream)
{
    byte[] serializedObject = Serializer.SerializeObject(obj);
    byte[] compressedObject = Compressor.Compress(serializedObject);

    var binaryWriter = new BinaryWriter(networkStream);
    binaryWriter.Write(compressedObject);

}