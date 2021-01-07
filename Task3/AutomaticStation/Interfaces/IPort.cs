using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;
using Task3.AutomaticStation.Models.Message;

namespace Task3.AutomaticStation.Interfaces
{
    public interface IPort
    {
        PortStatus Status { get; }
        string PhoneNumber { get; set; }

        event EventHandler<MessageEventArgs> MessageReceived;
        event EventHandler<CallEventArgs> IncomingCall;

        ConnectionError Connect(Terminal terminal);
        void Disconnect(Terminal terminal);

        void OnMessageSendingRequested(object sender, MessageSendingEventArgs e);
        void OnCalled(object sender, CallEventArgs e);
    }
}
