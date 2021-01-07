using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Call
{
    public class CallEventArgs:EventArgs
    {
        public string CallerPhoneNumber { get; }

        public string TargetPhonNumber { get; }

        public CallResponseCode ResponseCode { get; set; }

        public CallErrorCode ErrorCode { get; set; }

        public CallEventArgs(string callerPhoneNumber, string targetPhoneNumber)
        {
            CallerPhoneNumber = callerPhoneNumber;
            TargetPhonNumber = targetPhoneNumber;
        }
    }
}
