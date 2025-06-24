using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CLOMAProject
{
    public class ConnectionManager
    {
        public async Task HandleClientCommunication(TcpClient clientSocket)
        {
            try
            {
                using (NetworkStream stream = clientSocket.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    // Start a task to receive messages
                    var receiveTask = ReceiveMessagesAsync(reader, true);

                    // Send messages
                    await SendMessagesAsync(writer, false);

                    // Signal the client that we're done
                    clientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Communication error: {ex.Message}");
            }
        }

        public async Task HandleServerCommunication(TcpClient serverSocket)
        {
            try
            {
                using (NetworkStream stream = serverSocket.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    // Start a task to receive messages
                    var receiveTask = ReceiveMessagesAsync(reader, false);

                    // Send messages
                    await SendMessagesAsync(writer, true);

                    // Clean up
                    serverSocket.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Communication error: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync(StreamReader reader, bool isServer)
        {
            try
            {
                while (true)
                {
                    string receivedMessage = await reader.ReadLineAsync();

                    // Check if connection was closed
                    if (receivedMessage == null)
                    {
                        Console.WriteLine("\nThe other user has disconnected.");
                        break;
                    }

                    // Check for exit command
                    if (receivedMessage.Trim().ToLower() == "exit")
                    {
                        Console.WriteLine("\nThe other user ended the conversation.");
                        break;
                    }

                    // Create a message object
                    var message = new Message(receivedMessage, !isServer);

                    // Display the message
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nConnection lost: {ex.Message}");
            }
        }

        private async Task SendMessagesAsync(StreamWriter writer, bool isClient)
        {
            try
            {
                while (true)
                {
                    string messageText = Console.ReadLine();

                    // Check for exit command
                    if (messageText.Trim().ToLower() == "exit")
                    {
                        await writer.WriteLineAsync("exit");
                        break;
                    }

                    // Create message and send it
                    var message = new Message(messageText, !isClient);
                    await writer.WriteLineAsync(messageText);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError sending message: {ex.Message}");
            }
        }
    }
}
