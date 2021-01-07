using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Message
{
    public class MessageEventArgs : EventArgs
    {
		public MessageType Type { get; }

		public Message Message { get; }

		public MessageEventArgs(Message message, MessageType type)
		{
			Message = message;
			Type = type;
		}
	}
}
