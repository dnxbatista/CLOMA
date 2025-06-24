# CLOMA - CommandLine OneTime Message Application

## About
CLOMA (CommandLine OneTime Message Application) is a simple, secure messaging application that allows two users to communicate via LAN using only the command-line interface. The key focus of CLOMA is privacy and simplicity - once the conversation ends, no messages are saved, leaving no trace of the communication.

## Features
- **LAN-based messaging**: Connect directly with another user on the same local network
- **Command-line interface**: Simple, lightweight, and no graphical dependencies
- **No message persistence**: All messages are deleted after the conversation ends
- **Real-time communication**: Instant message delivery between users
- **Simple to use**: Minimal setup and straightforward operation
- **Private**: No logs, no history, no data storage

## Requirements
- .NET 5.0 or higher
- Two computers on the same LAN network
- Network connectivity with access to TCP port 13000

## Installation
1. Clone this repository or download the source files
2. Open a terminal/command prompt in the project directory
3. Build the application using:
   ```
   dotnet build
   ```
4. Run the compiled application using:
   ```
   dotnet run
   ```

## How to Use

### Hosting a Conversation (Server)
1. Start the application and select option `1` to host a conversation
2. The application will display your local IP address and listen for incoming connections
3. Wait for the other user to connect
4. Once connected, you can start sending messages
5. Type `exit` to end the conversation

### Joining a Conversation (Client)
1. Start the application and select option `2` to join a conversation
2. Enter the IP address of the host (server)
3. Once connected, you can start sending messages
4. Type `exit` to end the conversation

## Project Structure
- **Program.cs**: Application entry point and user interface
- **Server.cs**: Handles server-side functionality
- **Client.cs**: Manages client connections and communication
- **Message.cs**: Defines the message structure
- **ConnectionManager.cs**: Manages the communication between server and client

## Security Considerations
- CLOMA uses plain text communication without encryption
- It's designed for non-sensitive communication on trusted networks
- Do not use for transmitting sensitive or confidential information
- The application does not implement authentication - anyone with the server's IP can connect

## Development
Feel free to fork and extend this project. Some possible enhancements:
- Add encryption for secure messaging
- Support for more than two users (group chat)
- Message formatting and commands
- File transfer capabilities
- Connection authentication

## License
This project is open source and available under the [MIT License](https://opensource.org/licenses/MIT).