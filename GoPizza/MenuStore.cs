using System.Collections.Generic;

namespace GoPizza
{
    public static class MenuStore
    {
        public static Menu GetMenu()
        {
            var menu = new Menu();

            menu.Pizzas.AddRange(GetPizzas());
            menu.Toppings.AddRange(GetToppings());
            menu.BreadExtras.AddRange(GetBreads());

            return menu;
        }

        private static List<Bread> GetBreads()
        {
            return new List<Bread>
            {
                new Bread() { Name = "Thin crust", Price = 20 },
                new Bread() { Name = "Cheese crust", Price = 25 },
                new Bread() { Name = "Pan", Price = 10 }
            };
        }

        private static List<Topping> GetToppings()
        {
            return new List<Topping>
            {
                new Topping()
                {
                    Name = Constants.Toppings.Cheese,
                    Price = 20
                },
                new Topping()
                {
                    Name = Constants.Toppings.Olives,
                    Price = 20
                },
                new Topping()
                {
                    Name = Constants.Toppings.Onion,
                    Price = 10
                },
                new Topping()
                {
                    Name = Constants.Toppings.Chicken,
                    Price = 25
                },
                new Topping()
                {
                    Name = Constants.Toppings.CottageCheese,
                    Price = 15
                }
            };
        }

        private static List<Pizza> GetPizzas()
        {
            return new List<Pizza>
            {
                GetVeggieSupreme(),
                GetChickenSupreme(),
                GetDoubleChickenFeast(),
                GetVegFarmHouse(),
                GetMargarita()
            };
        }

        private static Pizza GetVeggieSupreme()
        {
            var pizza = new Pizza()
            {
                Name = "Veggie Supreme",
                Price = 250
            };
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Cheese });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Chicken });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Capsicum });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Onion });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.RedPaprika });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Mushroom });
            return pizza;
        }

        private static Pizza GetChickenSupreme()
        {
            var pizza = new Pizza()
            {
                Name = "Chicken Supreme",
                Price = 300
            };
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Cheese });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Chicken });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Meatball });
            return pizza;
        }

        private static Pizza GetDoubleChickenFeast()
        {
            var pizza = new Pizza()
            {
                Name = "Double Chicken Feast",
                Price = 350
            };
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Cheese });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Chicken });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Capsicum });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Onion });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.RedPaprika });
            return pizza;
        }

        private static Pizza GetVegFarmHouse()
        {
            var pizza = new Pizza()
            {
                Name = "Veg Farmhouse",
                Price = 300
            };
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Cheese });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Capsicum });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Onion });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.RedPaprika });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.BlackOlives });
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Corn });
            return pizza;
        }

        private static Pizza GetMargarita()
        {
            var pizza = new Pizza()
            {
                Name = "Margarita",
                Price = 225
            };
            pizza.Toppings.Add(new Topping() { Name = Constants.Toppings.Cheese });
            return pizza;
        }
    }
}
