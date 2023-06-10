using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkProgramming_ClientUDP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //endpoint = ip address + port (127.10.55.255:1024)

            UdpClient udpClient = new UdpClient();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("10.7.174.170"), 3344);

            string message = string.Empty;
            do
            {
                Console.Write("Enter a message (enter 'END to exit): ");
                message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, endPoint);

                IPEndPoint? serverEndPoint = null;
                byte[] response = udpClient.Receive(ref serverEndPoint);
                string responseMessage = Encoding.UTF8.GetString(response);
                Console.WriteLine($"Server response: {responseMessage} : {DateTime.Now.ToShortTimeString()}");

            } while (message != "END");
        }
    }
}