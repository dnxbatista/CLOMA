using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLOMAProject
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsServerMessage { get; set; }

        public Message(string content, bool isServerMessage)
        {
            Content = content;
            Timestamp = DateTime.Now;
            IsServerMessage = isServerMessage;
        }

        public override string ToString()
        {
            string senderPrefix = IsServerMessage ? "Server" : "Client";
            return $"[{Timestamp.ToString("HH:mm:ss")}] {senderPrefix}: {Content}";
        }
    }
}
