using System;
using System.Collections.Generic;
using Task3.AutomaticStation.Interfaces;

namespace Task3.BillingSystem.Interfaces
{
    interface IOperator
    {
        void AddAbonent(IAbonent abonent, IStation station);
        void DeleteAbonentById(Guid id);
        void AddStation(IStation station);
        ICollection<IAbonent> GetAbonentList();
    }
}
