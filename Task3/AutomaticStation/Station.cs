using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;
using Task3.BillingSystem.Interfaces;
using Task3.Logger;
using Task3.Logger.Interfaces;

namespace Task3.AutomaticStation
{
    class Station : IStation
    {
        public ICollection<IPort> Ports { get; }

        public event EventHandler<CallEventArgs> CallTerminate;
        public event EventHandler<CallEventArgs> CallRecordSend;
        public event EventHandler<BalanceEventArgs> BalanceRequest;

        public Station()
        {
            Ports = new List<IPort>();
        }

        public double GetBalanceByPhoneNumber(string value)
        {
            BalanceEventArgs eventArgs = new BalanceEventArgs();
            eventArgs.PhoneNumber = value;
            BalanceRequest?.Invoke(this, eventArgs);
            return eventArgs.Balance;
        }

        public IPort GetPortByPhoneNumber(string value)
        {
            return Ports.FirstOrDefault(p => p.PhoneNumber == value);
        }

        public void OnCallTerminate(object sender, CallEventArgs e)
        {
            var inPort = GetPortByPhoneNumber(e.CallerPhoneNumber);
            var outPort = GetPortByPhoneNumber(e.TargetPhoneNumber);

            if (inPort.Status != PortStatus.FREE)
            {
                inPort.Status = PortStatus.CONNECTED;
            }

            if (outPort.Status != PortStatus.FREE)
            {
                outPort.Status = PortStatus.CONNECTED;
            }

            var a =GetPortStatusList();
            CallRecordSend?.Invoke(sender, e);
        }

        public void CallingRequest(object sender, CallEventArgs e)
        {
            IPort InPort = GetPortByPhoneNumber(e.TargetPhoneNumber);
            if (InPort != null)
            {
                if (GetBalanceByPhoneNumber(e.CallerPhoneNumber) <= 0)
                {
                    e.ErrorCode = CallErrorCode.NOT_ENOUGH_MONEY;
                    GetPortByPhoneNumber(e.CallerPhoneNumber).CallingErrorMessage(e);
                    return;
                }
                if (InPort.Status == PortStatus.FREE)
                {
                    e.ErrorCode = CallErrorCode.NOT_EXIST;
                    OnCallTerminate(sender, e);
                    GetPortByPhoneNumber(e.CallerPhoneNumber).CallingErrorMessage(e);
                    return;
                }
                if (InPort.Status != PortStatus.BUSY)
                {
                    InPort.OnIncomingCall(e);
                }
                else
                {
                    e.ErrorCode = CallErrorCode.BUSY;
                    OnCallTerminate(sender, e);
                    GetPortByPhoneNumber(e.CallerPhoneNumber).CallingErrorMessage(e);
                }
            }
            else
            {
                e.ErrorCode = CallErrorCode.WRONG_NUMBER;
                GetPortByPhoneNumber(e.CallerPhoneNumber).CallingErrorMessage(e);
            }
        }

        public ICollection<string> GetPortStatusList()
        {
            ICollection<string> ports = new List<string>();
            foreach (var port in Ports)
            {
                string statusString;
                switch (port.Status)
                {
                    case PortStatus.BUSY:
                        {
                            statusString = "BUSY";
                            break;
                        }
                    case PortStatus.CONNECTED:
                        {
                            statusString = "CONNECTED";
                            break;
                        }
                    case PortStatus.FREE:
                        {
                            statusString = "FREE";
                            break;
                        }
                    default:
                        {
                            statusString = "Unknown";
                            break;
                        }
                }

                ports.Add(port.PhoneNumber + " - " + statusString);
            }
            return ports;
        }
    }
}
