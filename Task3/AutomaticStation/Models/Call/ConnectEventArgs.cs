﻿using System;

namespace Task3.AutomaticStation.Models
{
    public class ConnectEventArgs: EventArgs
    {
        public PortStatus Status { get; }

        public ConnectEventArgs(PortStatus status)
        {
            Status = status;
        }
    }
}
