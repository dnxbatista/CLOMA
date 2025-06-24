using System.Net.Sockets;


namespace CLOMAProject
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("CLOMA - CommandLine OneTime Message Application");
            Console.WriteLine("===============================================");
            Console.WriteLine("1. Host a conversation (Server)");
            Console.WriteLine("2. Join a conversation (Client)");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            if (option == "1")
            {
                var server = new Server();
                await server.StartServer();
            }
            else if (option == "2")
            {
                Console.Write("Enter server IP address: ");
                string ipAddress = Console.ReadLine();

                var client = new Client();
                await client.ConnectToServer(ipAddress);
            }
            else
            {
                Console.WriteLine("Invalid option. Exiting application.");
            }
        }
    }
}
