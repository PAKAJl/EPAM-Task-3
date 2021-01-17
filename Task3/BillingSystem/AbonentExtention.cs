using System;
using System.Collections.Generic;
using Task3.BillingSystem.Models;

namespace Task3.BillingSystem
{
    public static class AbonentExtention
    {
        public static ICollection<Call> Filter(this ICollection<Call> calls, FilterParameters param, string value)
        {
            ICollection<Call> callList = calls;

            ICollection<Call> result = new List<Call>();
            switch (param)
            {
                case FilterParameters.ABONENT:
                    {
                        foreach (var call in callList)
                        {
                            if (call.TargetPhoneNumber == value)
                            {
                                result.Add(call);
                            }
                        }
                        break;
                    }
                case FilterParameters.CALL_DATE:
                    {
                        DateTime date = Convert.ToDateTime(value).Date;
                        Console.WriteLine(date);
                        foreach (var call in callList)
                        {
                            if (call.DateTimeBegin.Date == date)
                            {
                                result.Add(call);
                            }
                        }
                        break;
                    }
                case FilterParameters.COST:
                    {
                        double cost = double.Parse(value);
                        foreach (var call in callList)
                        {
                            if (call.Cost > cost - 2 && call.Cost < cost + 2)
                            {
                                result.Add(call);
                            }
                        }
                        break;
                    }
            }
            return result;
        }
    }
}
