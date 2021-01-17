using System;
using System.Collections.Generic;

namespace Task3.BillingSystem.Models
{
    public class AbonentEventArgs : EventArgs
    {
        public ICollection<Call> Calls { get; set; }

        public AbonentEventArgs()
        {
            Calls = new List<Call>();
        }
    }
}
