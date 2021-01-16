using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;

namespace Task3.AutomaticStation.Interfaces
{
    public interface ITerminal
    {
        event EventHandler<CallEventArgs> Called;
        event EventHandler<ConnectEventArgs> Connected;
        event EventHandler<CallEventArgs> CallTerminate;

        CallErrorCode Call(string PhoneNumber);
        void OnIncomingCall(object sender, CallEventArgs e);
        void Connect();
        void Disconnect();
        void CallingError(CallEventArgs e);
    }
}
