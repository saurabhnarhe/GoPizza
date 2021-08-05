using System.Collections.Generic;

namespace GoPizza
{
    public interface IPizzaCostCalculator
    {
        decimal GetCost(string pizza, List<string> extrasToAdd = null, List<string> extrasToRemove = null);
    }
}