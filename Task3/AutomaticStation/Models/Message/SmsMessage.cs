using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Message
{
    public class SmsMessage : Message
    {
        public string Text { get; }

        public SmsMessage(string sender, string text) : base(sender)
        {
            Text = text;
        }
    }
}
