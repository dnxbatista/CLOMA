using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CLOMAProject
{
    public class Server
    {
        private TcpListener _tcpListener;
        private readonly int _port = 13000;
        private ConnectionManager _connectionManager;

        public async Task StartServer()
        {
            try
            {
                // Get local IP address
                string localIp = GetLocalIPAddress();

                _tcpListener = new TcpListener(IPAddress.Parse(localIp), _port);
                _connectionManager = new ConnectionManager();

                _tcpListener.Start();

                Console.WriteLine($"Server started on {localIp}:{_port}");
                Console.WriteLine("Waiting for a client to connect...");

                // Accept client connection
                TcpClient clientSocket = await _tcpListener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected! Starting conversation...");
                Console.WriteLine("Type your messages and press Enter to send.");
                Console.WriteLine("Type 'exit' to end the conversation.");
                Console.WriteLine("----------------------------------------");

                // Handle client communication
                await _connectionManager.HandleClientCommunication(clientSocket);

                // Cleanup when done
                _tcpListener.Stop();
                Console.WriteLine("\nConversation ended. All messages are not saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1"; // Fallback to localhost
        }
    }
}
