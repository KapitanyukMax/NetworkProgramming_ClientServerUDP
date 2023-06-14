using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkProgrammingHW_ClientUDP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.107"), 3040);

            string message = string.Empty;
            do
            {
                Console.Write("Enter a message (enter 'END' to exit): ");
                message = Console.ReadLine() ?? string.Empty;
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length, endPoint);

                IPEndPoint? serverEndPoint = null;
                string response = Encoding.UTF8.GetString(client.Receive(ref serverEndPoint));
                Console.WriteLine($"Server response: {response} : {DateTime.Now.ToShortTimeString()}");
            } while (message != "END");

            Console.WriteLine("Closing the client application...");
        }
    }
}