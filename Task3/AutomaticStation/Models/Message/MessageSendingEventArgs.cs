using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Message
{
    public class MessageSendingEventArgs : MessageEventArgs
    {
        public MessageSendErrorCode ErrorCode { get; set; }

        public MessageSendingEventArgs(Message message, MessageType type) : base(message, type)
        {
            ErrorCode = MessageSendErrorCode.UNKNOWN_ERROR;
        }
    }
}
