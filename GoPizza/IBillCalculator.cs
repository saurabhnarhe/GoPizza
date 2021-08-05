using System.Collections.Generic;

namespace GoPizza
{
    public interface IBillCalculator
    {
        decimal GetBill(List<string> rawOrders);
    }
}