using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models.Call;
using Task3.AutomaticStation.Models.Message;

namespace Task3.AutomaticStation
{
    public class Terminal : ITerminal
    {
        public event EventHandler<MessageSendingEventArgs> MessageSendingRequested;
        public event EventHandler<CallEventArgs> Called;

        public string PhoneNumber { get; }

        public Terminal(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void OnIncomingCall(object sender, CallEventArgs e)
        {
            Console.WriteLine($"Incomming call by {e.CallerPhoneNumber}. Do you want to accept that?");
            // Console.Read();
        }

        public void OnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            Console.WriteLine($"On message received. Sender is {messageEventArgs.Message.Sender}, Text is {messageEventArgs.ToString()}");
        }

        public MessageSendErrorCode SendMessage(Message message, MessageType type)
        {
            var eventArgs = new MessageSendingEventArgs(message, type);

            MessageSendingRequested?.Invoke(this, eventArgs);

            return eventArgs.ErrorCode;
        }

        public CallErrorCode Call(string targetPhoneNumber)
        {
            var eventArgs = new CallEventArgs(PhoneNumber, targetPhoneNumber);

            Called?.Invoke(this, eventArgs);

            return eventArgs.ErrorCode;
        }
    }
}
