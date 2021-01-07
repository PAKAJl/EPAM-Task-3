using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;
using Task3.AutomaticStation.Models.Message;

namespace Task3.AutomaticStation
{
    class Port : IPort
    {
        public PortStatus Status { get; private set; }

        public string PhoneNumber { get; set; }

        public event EventHandler<MessageEventArgs> MessageReceived;
        public event EventHandler<CallEventArgs> IncomingCall;

        public ConnectionError Connect(Terminal terminal)
        {
            if (Status != PortStatus.CONNECTED)
            {
                MessageReceived += terminal.OnMessageReceived;
                IncomingCall += terminal.OnIncomingCall;

                // subscribe port to terminal messages
                terminal.MessageSendingRequested += OnMessageSendingRequested;
                terminal.Called += OnCalled;

                Status = PortStatus.CONNECTED;

                return ConnectionError.OK;
            }
            else
            {
                return ConnectionError.ALREADY_CONNECTED;
            }
        }

        public void Disconnect(Terminal terminal)
        {
            if (Status != PortStatus.FREE)
            {
                MessageReceived -= terminal.OnMessageReceived;
                IncomingCall -= terminal.OnIncomingCall;

                terminal.MessageSendingRequested -= OnMessageSendingRequested;
                terminal.Called -= OnCalled;

                Status = PortStatus.FREE;
            }
        }

        public void OnCalled(object sender, CallEventArgs e)
        {
            
        }

        public void OnMessageSendingRequested(object sender, MessageSendingEventArgs e)
        {
           
        }
    }
}
