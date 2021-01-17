using System;

namespace Task3.AutomaticStation.Models
{
    public class BalanceEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }

        public double Balance { get; set; }
    }
}
