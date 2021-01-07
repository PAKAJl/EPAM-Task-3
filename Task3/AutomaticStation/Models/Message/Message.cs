using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Message
{
    public class Message
    {
        public string Sender { get; }

        public Message(string sender)
        {
            Sender = sender;
        }
    }
}
