using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;

namespace Task3.AutomaticStation.Interfaces
{
    public interface IStation
    {
        ICollection<IPort> Ports { get; }

        event EventHandler<CallEventArgs> CallRecordSend;
        event EventHandler<BalanceEventArgs> BalanceRequest;

        IPort GetPortByPhoneNumber(string value);
        void OnCallTerminate(object sender, CallEventArgs e);
        ICollection<string> GetPortStatusList();
        void CallingRequest(object sender, CallEventArgs e);
        double GetBalanceByPhoneNumber(string value);    }
}
