using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models
{
    public class BalanceEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }

        public double Balance { get; set; }
    }
}
