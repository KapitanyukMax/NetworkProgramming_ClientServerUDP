using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkProgrammingHW_ServerUDP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.107"), 3040);
            UdpClient server = new UdpClient(endPoint);

            while (true)
            {
                IPEndPoint? clientEndPoint = null;
                Console.WriteLine("Waiting for the request...");
                byte[] request = server.Receive(ref clientEndPoint);

                string message = Encoding.UTF8.GetString(request);
                Console.WriteLine($"Received message: {message} : {DateTime.Now.ToShortTimeString()} from: {clientEndPoint}");

                byte[] response = Encoding.UTF8.GetBytes("Thanks for the request!");
                server.Send(response, response.Length, clientEndPoint);

                //if (message == "END")
                //    break;
            }
        }
    }
}