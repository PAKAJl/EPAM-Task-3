using Task3.BillingSystem.Interfaces;

namespace Task3.BillingSystem.Models
{
    public class Tariff : ITariff
    {
        public double CostPerMinute { get; }

        public Tariff()
        {
            CostPerMinute = 10f;
        }
    }
}
