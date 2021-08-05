using System;
using System.Collections.Generic;
using Xunit;

namespace GoPizza.Fixture
{
    public class PizzaOrderValidatorFixture
    {
        private readonly IPizzaOrderValidator _validator;

        private static readonly string _pizza = "Margarita";
        private static readonly string _nonAvailablePizza = "NonAvailablePizza";
        private static readonly string _topping = "Cheese";
        private static readonly string _nonAvailableTopping = "NonAvailableTopping";

        public PizzaOrderValidatorFixture()
        {
            _validator = new PizzaOrderValidator(GetMenu());
        }

        private Menu GetMenu()
        {
            var menu = new Menu();
            var pizza = new Pizza()
            {
                Name = _pizza,
                Price = 250
            };
            menu.Pizzas.Add(pizza);
            menu.Toppings.Add(new Topping() { Name = _topping, Price = 10 });
            return menu;
        }

        [Fact]
        public void ShouldNotThrowExceptionWhenValidOrder()
        {
            var order = new PizzaOrder() { PizzaName = _pizza };
            order.ExtrasToAdd.Add(_topping);
            var orders = new List<PizzaOrder>() { order };

            _validator.Validate(orders);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public void ShouldThrowExceptionWhenInvalidPizzaName(string name)
        {
            var orders = new List<PizzaOrder>() { new PizzaOrder() { PizzaName = name } };
            var exception = Assert.Throws<Exception>(() => _validator.Validate(orders));
            Assert.Equal("Base pizza name missing", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenNonAvailablePizza()
        {
            var orders = new List<PizzaOrder>() { new PizzaOrder() { PizzaName = _nonAvailablePizza } };
            var exception = Assert.Throws<Exception>(() => _validator.Validate(orders));
            Assert.Equal($"Oops, we dont serve pizza '{_nonAvailablePizza}', try something from menu.", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenTryingToAddNonAvailableTopping()
        {
            var order = new PizzaOrder() { PizzaName = _pizza };
            order.ExtrasToAdd.Add(_nonAvailableTopping);
            var orders = new List<PizzaOrder>() { order };

            var exception = Assert.Throws<Exception>(() => _validator.Validate(orders));
            Assert.Equal($"Oops, we dont serve extra '{_nonAvailableTopping}', try something from menu.", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenTryingToRemoveAlreadyRemovedTopping()
        {
            var order = new PizzaOrder() { PizzaName = _pizza };
            order.ExtrasToRemove.Add(_topping);
            order.ExtrasToRemove.Add(_topping);
            var orders = new List<PizzaOrder>() { order };

            var exception = Assert.Throws<Exception>(() => _validator.Validate(orders));
            Assert.Equal("Can't remove already removed extra", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenTryingToRemoveNonAvailableTopping()
        {
            var order = new PizzaOrder() { PizzaName = _pizza };
            order.ExtrasToRemove.Add(_nonAvailableTopping);
            var orders = new List<PizzaOrder>() { order };

            var exception = Assert.Throws<Exception>(() => _validator.Validate(orders));
            Assert.Equal($"Can not remove {_nonAvailableTopping}", exception.Message);
        }
    }
}
