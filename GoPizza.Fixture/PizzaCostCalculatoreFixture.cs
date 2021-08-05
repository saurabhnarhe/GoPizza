using System.Collections.Generic;
using Xunit;

namespace GoPizza.Fixture
{
    public class PizzaCostCalculatoreFixture
    {
        private readonly IPizzaCostCalculator _pizzaCostCalculator;

        private static readonly string _pizza = "Margarita";
        private static readonly decimal _pizzaPrice = 250;
        private static readonly string _toppingForAddition = "Cheese";
        private static readonly decimal _toppingForAdditionPrice = 20;
        private static readonly string _toppingForRemoval = "Corn";
        private static readonly decimal _toppingForRemovalPrice = 10;

        public PizzaCostCalculatoreFixture()
        {
            _pizzaCostCalculator = new PizzaCostCalculator(GetMenu());
        }

        private Menu GetMenu()
        {
            var menu = new Menu();
            var pizza = new Pizza()
            {
                Name = _pizza,
                Price = _pizzaPrice
            };
            var availableToppingForRemoval = new Topping() { Name = _toppingForRemoval, Price = _toppingForRemovalPrice };
            var availableToppingForAddition = new Topping() { Name = _toppingForAddition, Price = _toppingForAdditionPrice };

            pizza.Toppings.Add(availableToppingForRemoval);
            menu.Pizzas.Add(pizza);

            menu.Toppings.Add(availableToppingForAddition);
            menu.Toppings.Add(availableToppingForRemoval);

            return menu;
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            var extrasToAdd = new List<string>() { _toppingForAddition };
            var extrasToRemove = new List<string>() { _toppingForRemoval };

            var price = _pizzaCostCalculator.GetCost(_pizza, extrasToAdd, extrasToRemove);

            var expectedPrice = (_pizzaPrice + _toppingForAdditionPrice) - _toppingForRemovalPrice;
            Assert.Equal(expectedPrice, price);
        }
    }
}
