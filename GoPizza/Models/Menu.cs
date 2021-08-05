using System.Collections.Generic;

namespace GoPizza
{
    public class Menu
    {
        public List<Pizza> Pizzas { get; } = new List<Pizza>();
        public List<Topping> Toppings { get; } = new List<Topping>();
        public List<Bread> BreadExtras { get; } = new List<Bread>();
    }
}
