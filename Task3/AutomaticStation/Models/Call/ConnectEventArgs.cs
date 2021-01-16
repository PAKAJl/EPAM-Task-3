using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models
{
    public class ConnectEventArgs: EventArgs
    {
        public PortStatus Status { get; }

        public ConnectEventArgs(PortStatus status)
        {
            Status = status;
        }
    }
}
