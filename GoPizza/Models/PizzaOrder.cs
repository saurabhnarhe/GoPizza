using System.Collections.Generic;

namespace GoPizza
{
    public class PizzaOrder
    {
        public string PizzaName { get; set; }
        public List<string> ExtrasToAdd { get; } = new List<string>();
        public List<string> ExtrasToRemove { get; } = new List<string>();
    }
}