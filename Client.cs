using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CLOMAProject
{
    public class Client
    {
        private TcpClient _tcpClient;
        private ConnectionManager _connectionManager;
        private readonly int _port = 13000;

        public async Task ConnectToServer(string serverIp)
        {
            try
            {
                _tcpClient = new TcpClient();
                _connectionManager = new ConnectionManager();

                Console.WriteLine($"Connecting to {serverIp}:{_port}...");

                await _tcpClient.ConnectAsync(serverIp, _port);

                Console.WriteLine("Connected to server!");
                Console.WriteLine("Type your messages and press Enter to send.");
                Console.WriteLine("Type 'exit' to end the conversation.");
                Console.WriteLine("----------------------------------------");

                // Handle server communication
                await _connectionManager.HandleServerCommunication(_tcpClient);

                Console.WriteLine("\nConversation ended. All messages are not saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client error: {ex.Message}");
            }
        }
    }
}
