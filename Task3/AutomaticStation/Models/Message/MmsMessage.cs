using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Message
{
    public class MmsMessage : Message
    {
        public byte[] ImageBytes { get; }

        public MmsMessage(string sender, byte[] imageBytes) : base(sender)
        {
            ImageBytes = imageBytes;
        }
    }
}
