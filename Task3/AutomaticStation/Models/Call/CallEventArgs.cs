using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticStation.Models.Call
{
    public class CallEventArgs:EventArgs
    {
        public string CallerPhoneNumber { get; set; }

        public string TargetPhoneNumber { get; }

        public CallResponseCode ResponseCode { get; set; }

        public CallErrorCode ErrorCode { get; set; }

        public DateTime DateTimeBeginCall { get; set; }

        public DateTime DataTimeEndCall { get; set; }

        public CallEventArgs(string targetPhoneNumber)
        {
            TargetPhoneNumber = targetPhoneNumber;
            ErrorCode = CallErrorCode.UNKNOWN;
            ResponseCode = CallResponseCode.UNKNOWN;
        }
    }
}
