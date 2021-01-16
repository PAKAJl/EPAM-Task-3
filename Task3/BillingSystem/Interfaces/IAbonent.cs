using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.BillingSystem.Models;

namespace Task3.BillingSystem.Interfaces
{
    public interface IAbonent
    {
        Guid Id { get; }
        ITerminal Terminal { get; }
        double Balance { get; set; }
        string PhoneNumber { get; }
        ITariff Tariff { get; set; }

        event EventHandler<AbonentEventArgs> CallReportRequest;

        void TopUpBalance(double value);
        ICollection<Call> GetCallReport();
    }
}
