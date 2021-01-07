using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Models.Call;

namespace Task3.AutomaticStation.Interfaces
{
    interface IStation
    {
        ICollection<IPort> ports { get; }

        event EventHandler<CallEventArgs> Calling;

        IPort GetPortByPhoneNumber(string value);
        void SendCallRecord();
    }
}
