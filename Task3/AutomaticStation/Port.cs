﻿using System;
using Task3.AutomaticStation.Interfaces;
using Task3.AutomaticStation.Models;
using Task3.AutomaticStation.Models.Call;

namespace Task3.AutomaticStation
{
    class Port : IPort
    {
        public PortStatus Status { get; set; }

        public string PhoneNumber { get; set; }
        public event EventHandler<CallEventArgs> IncomingCall;
        public event EventHandler<CallEventArgs> OutcomingCall;
        public event EventHandler<CallEventArgs> PortBusy;
        public event EventHandler<CallEventArgs> CallTerminate;

        private ITerminal _terminal;

        public Port(string phoneNumber, ITerminal terminal)
        {
            Status = PortStatus.FREE;
            PhoneNumber = phoneNumber;
            _terminal = terminal;
            _terminal.Connected += OnTerminalStatusRequest;
        }

        private ConnectionError Connect()
        {
            if (Status != PortStatus.CONNECTED)
            {
                IncomingCall += _terminal.OnIncomingCall;

                // subscribe port to terminal messages
                _terminal.Called += OnOutcomingCall;
                _terminal.CallTerminate += OnCallTerminate;
                Status = PortStatus.CONNECTED;

                return ConnectionError.OK;
            }
            else
            {
                return ConnectionError.ALREADY_CONNECTED;
            }
        }

        private void Disconnect()
        {
            if (Status != PortStatus.FREE)
            {
                IncomingCall -= _terminal.OnIncomingCall;

                _terminal.Called -= OnOutcomingCall;

                Status = PortStatus.FREE;
            }
        }

        public void OnIncomingCall(CallEventArgs e)
        {
            Status = PortStatus.BUSY;
            IncomingCall?.Invoke(this, e);
        }

        public void OnOutcomingCall(object sender, CallEventArgs e)
        {
            Status = PortStatus.BUSY;
            e.CallerPhoneNumber = PhoneNumber;
            OutcomingCall?.Invoke(sender, e);
        }

        public void CallingErrorMessage(CallEventArgs e)
        {
            _terminal.CallingError(e);
        }

        public void OnCallTerminate(object sender, CallEventArgs e)
        {
            Status = PortStatus.CONNECTED;
            CallTerminate?.Invoke(sender, e);
        }

        public void OnTerminalStatusRequest(object sender, ConnectEventArgs e)
        {
            if (e.Status == PortStatus.CONNECTED)
            {
                Connect();
            }
            else
            {
                Disconnect();
            }
        }
    }
}
