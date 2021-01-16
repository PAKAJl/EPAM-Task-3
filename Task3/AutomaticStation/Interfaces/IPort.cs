using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;

namespace Task3.AutomaticStation.Interfaces
{
    public interface IPort
    {
        string PhoneNumber { get; set; }
        PortStatus Status { get; set; }

        event EventHandler<CallEventArgs> IncomingCall;
        event EventHandler<CallEventArgs> OutcomingCall;
        event EventHandler<CallEventArgs> CallTerminate;

        void OnIncomingCall(CallEventArgs e);
        void OnOutcomingCall(object sender, CallEventArgs e);
        void CallingErrorMessage(CallEventArgs e);
        void OnCallTerminate(object sender, CallEventArgs e);


    }
}
