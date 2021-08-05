using System;
using System.Collections.Generic;
using System.Linq;

namespace GoPizza
{
    public class PizzaOrderValidator : IPizzaOrderValidator
    {
        private readonly Menu _menu;

        public PizzaOrderValidator(Menu menu)
        {
            _menu = menu;
        }

        public void Validate(List<PizzaOrder> orders)
        {
            foreach (var order in orders)
            {
                Validate(order);
            }
        }

        #region Private helper methods

        private void Validate(PizzaOrder order)
        {
            ValidatePizzaName(order.PizzaName);
            ValidateExtrasExists(order.ExtrasToAdd);
            var pizza = _menu.Pizzas.SingleOrDefault(p => p.Name.Equals(order.PizzaName, StringComparison.OrdinalIgnoreCase));
            ValidateExtrasToRemove(pizza, order.ExtrasToRemove);
        }

        private void ValidatePizzaName(string pizzaName)
        {
            if (string.IsNullOrWhiteSpace(pizzaName))
                throw new Exception("Base pizza name missing");
            if (!_menu.Pizzas.Exists(pizza => pizza.Name.Equals(pizzaName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"Oops, we dont serve pizza '{pizzaName}', try something from menu.");
        }

        private void ValidateExtrasExists(List<string> extras)
        {
            foreach (var extra in extras)
            {
                if (!_menu.Toppings.Exists(topping => topping.Name.Equals(extra, StringComparison.OrdinalIgnoreCase)) && !_menu.BreadExtras.Exists(breadExtra => breadExtra.Name.Equals(extra, StringComparison.OrdinalIgnoreCase)))
                    throw new Exception($"Oops, we dont serve extra '{extra}', try something from menu.");
            }
        }

        private void ValidateExtrasToRemove(Pizza pizza, List<string> extrasToRemove)
        {
            if (extrasToRemove.Count != extrasToRemove.Distinct().Count())
                throw new Exception("Can't remove already removed extra");
            foreach (var extra in extrasToRemove)
            {
                if (!pizza.Toppings.Exists(topping => topping.Name.Equals(extra, StringComparison.OrdinalIgnoreCase)) && !pizza.BreadExtras.Exists(breadExtra => breadExtra.Name.Equals(extra, StringComparison.OrdinalIgnoreCase)))
                    throw new Exception($"Can not remove {extra}");
            }
        }

        #endregion
    }
}
