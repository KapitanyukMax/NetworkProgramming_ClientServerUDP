using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkProgramming_ServerUDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("10.7.174.170"), 3344);
            UdpClient server = new UdpClient(endPoint);

            while (true)
            {
                Console.WriteLine("...Waiting for the request...");

                IPEndPoint? clientEndPoint = null;
                byte[] request = server.Receive(ref clientEndPoint);
                string message = Encoding.UTF8.GetString(request);
                Console.WriteLine($"Received message: {message} : {DateTime.Now.ToShortTimeString()} from: {clientEndPoint}");

                //send response to the client
                byte[] response = Encoding.UTF8.GetBytes("Thanks for the request");
                server.Send(response, response.Length, clientEndPoint);
            }
        }
    }
}