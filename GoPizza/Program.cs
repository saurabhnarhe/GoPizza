using System;
using System.Collections.Generic;

namespace GoPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<string>()
            {
                // "Chicken Supreme, cheese, olives, Thin Crust",
                // “Veggie Supreme, cheese, -onion”
                "Double Chicken feast, cheese, cottage cheese, olives, Thin Crust, -onion"
            };

            var menu = MenuStore.GetMenu();
            var pizzaCostCalculator = new PizzaCostCalculator(menu);
            var pizzaOrderValidator = new PizzaOrderValidator(menu);
            var billCalculator = new PizzaBillCalculator(pizzaOrderValidator, pizzaCostCalculator);

            var ans = billCalculator.GetBill(orders);
            Console.WriteLine(ans);
            Console.ReadKey(true);
        }
    }
}
