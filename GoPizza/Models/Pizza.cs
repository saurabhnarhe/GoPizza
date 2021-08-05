using System.Collections.Generic;

namespace GoPizza
{
    public class Pizza
    {
        public string Name { get; set; }
        public List<Topping> Toppings { get; } = new List<Topping>();
        public List<Bread> BreadExtras { get; } = new List<Bread>();
        public decimal Price { get; set; }
    }
}
