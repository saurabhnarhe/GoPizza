using System;
using System.Collections.Generic;
using System.Linq;

namespace GoPizza
{
    public class PizzaCostCalculator : IPizzaCostCalculator
    {
        private readonly Menu _menu;

        public PizzaCostCalculator(Menu menu)
        {
            _menu = menu;
        }

        public decimal GetCost(string pizza, List<string> extrasToAdd = null, List<string> extrasToRemove = null)
        {
            return (GetBasePrize(pizza) +
                    GetExtrasTotalCost(extrasToAdd)) -
                    GetExtrasTotalCost(extrasToRemove);
        }

        #region Private helper method

        private decimal GetBasePrize(string pizzaName)
        {
            return _menu.Pizzas.FirstOrDefault(p => p.Name.Equals(pizzaName, StringComparison.OrdinalIgnoreCase)).Price;
        }

        private decimal GetExtrasTotalCost(List<string> extrasToAdd)
        {
            if (extrasToAdd == null) return 0;
            return extrasToAdd.Sum(extra => GetExtrasPrice(extra));
        }

        private decimal GetExtrasPrice(string extraName)
        {
            var extraTopping = _menu.Toppings.FirstOrDefault(topping => topping.Name.Equals(extraName, StringComparison.OrdinalIgnoreCase));
            if (extraTopping != null)
                return extraTopping.Price;
            var breadExtra = _menu.BreadExtras.FirstOrDefault(be => be.Name.Equals(extraName, StringComparison.OrdinalIgnoreCase));
            if (breadExtra != null)
                return breadExtra.Price;
            return 0;
        }

        #endregion
    }
}
