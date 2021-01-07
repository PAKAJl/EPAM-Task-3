using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Models.Call;
using Task3.AutomaticStation.Models.Message;

namespace Task3.AutomaticStation.Interfaces
{
    interface ITerminal
    {
        event EventHandler<MessageSendingEventArgs> MessageSendingRequested;
        event EventHandler<CallEventArgs> Called;

        string PhoneNumber { get; }

        MessageSendErrorCode SendMessage(Message message, MessageType type);
        CallResponseCode Call(string PhoneNumber);
        void OnMessageReceived(object sender, MessageEventArgs messageEventArgs);
        void OnIncomingCall(object sender, CallEventArgs e);
    }
}
