using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models.Call;
using Task3.BillingSystem.Models;

namespace Task3.BillingSystem.Interfaces
{
    interface IOperator
    {
        void AddAbonent(IAbonent abonent, IStation station);
        void DeleteAbonentById(Guid id);
        void AddStation(IStation station);
        void OnCallRecordSend(object sender, CallEventArgs e);
    }
}
