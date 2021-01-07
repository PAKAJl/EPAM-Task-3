using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models.Call;

namespace Task3.AutomaticStation
{
    class Station : IStantion
    {
        public ICollection<IPort> ports => throw new NotImplementedException();

        public event EventHandler<CallEventArgs> Calling;

        public IPort GetPortByPhoneNumber(string value)
        {
            throw new NotImplementedException();
        }

        public void SendCallRecord()
        {
            throw new NotImplementedException();
        }
    }
}
