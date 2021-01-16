using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.BillingSystem.Interfaces;
using Task3.BillingSystem.Models;

namespace Task3.BillingSystem
{
    class Abonent : IAbonent
    {
        public Guid Id { get; private set; }
        public ITerminal Terminal { get; private set; }
        public double Balance { get; set; }
        public string PhoneNumber { get; }
        public ITariff Tariff { get; set; }

        public event EventHandler<AbonentEventArgs> CallReportRequest;

        public Abonent(ITariff tariff, string phoneNumber, ITerminal terminal)
        {
            Id = Guid.NewGuid();
            Balance = 0;
            Tariff = tariff;
            PhoneNumber = phoneNumber;
            Terminal = terminal;
        }

        public void TopUpBalance(double value)
        {
            Balance += value;
        }

        public ICollection<Call> GetCallReport()
        {
            var eventArgs = new AbonentEventArgs();
            CallReportRequest?.Invoke(this, eventArgs);

            return eventArgs.Calls;
        }
    }
}
