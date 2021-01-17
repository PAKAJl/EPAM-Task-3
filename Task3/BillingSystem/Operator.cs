using System;
using System.Collections.Generic;
using System.Linq;
using Task3.AutomaticStation;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;
using Task3.BillingSystem.Interfaces;
using Task3.BillingSystem.Models;

namespace Task3.BillingSystem
{
    public class Operator : IOperator
    {
        private ICollection<IAbonent> _abonentList;
        private ICollection<Call> _callList;
        private ICollection<IStation> _stationList;

        public Operator()
        {
            _abonentList = new List<IAbonent>();
            _callList = new List<Call>();
            _stationList = new List<IStation>();
        }

        public void AddAbonent(IAbonent abonent, IStation station)
        {
            _abonentList.Add(abonent);
            abonent.CallReportRequest += OnCallReportRequest;
            IPort port = new Port(abonent.PhoneNumber, abonent.Terminal);
            station.Ports.Add(port);
            port.OutcomingCall += station.CallingRequest;
            port.CallTerminate += station.OnCallTerminate;
        }

        public void DeleteAbonentById(Guid id)
        {
            IAbonent abonent = _abonentList.FirstOrDefault(user => user.Id == id);
            _abonentList.Remove(abonent);
        }

        public void AddStation(IStation station)
        {
            station.BalanceRequest += OnBalanceRequest;
            station.CallRecordSend += OnCallRecordSend;
            _stationList.Add(station);

        }

        private void OnBalanceRequest(object sender, BalanceEventArgs e)
        {
            e.Balance = _abonentList.FirstOrDefault(a => a.PhoneNumber == e.PhoneNumber).Balance;
        }

        private void OnCallRecordSend(object sender, CallEventArgs e)
        {
            IAbonent abonent = _abonentList.FirstOrDefault(a => a.PhoneNumber == e.CallerPhoneNumber);
            Call call = new Call(e, abonent.Tariff);
            abonent.Balance -= call.Cost;
            _callList.Add(call);
        }

        private void OnCallReportRequest(object sender, AbonentEventArgs e)
        {
            var abonent = sender as IAbonent;
            foreach (var call in _callList)
            {
                if (call.CallerPhoneNumber == abonent.PhoneNumber || call.TargetPhoneNumber == abonent.PhoneNumber)
                {
                    e.Calls.Add(call);
                }
            }
        }

        public ICollection<IAbonent> GetAbonentList()
        {
            return _abonentList;
        }
    }
}
