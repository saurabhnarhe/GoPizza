using System;
using System.Collections.Generic;
using System.Linq;

namespace GoPizza
{
    public class PizzaBillCalculator : IBillCalculator
    {
        private readonly IPizzaCostCalculator _pizzaCostCalculator;
        private readonly IPizzaOrderValidator _pizzaOrderValidator;

        public PizzaBillCalculator(IPizzaOrderValidator pizzaOrderValidator, IPizzaCostCalculator pizzaCostCalculator)
        {
            _pizzaCostCalculator = pizzaCostCalculator;
            _pizzaOrderValidator = pizzaOrderValidator;
        }

        public decimal GetBill(List<string> rawOrders)
        {
            var orders = BuildOrders(rawOrders);
            _pizzaOrderValidator.Validate(orders);
            return orders.Sum(order => _pizzaCostCalculator.GetCost(order.PizzaName, order.ExtrasToAdd, order.ExtrasToRemove));
        }

        #region Private helper methods

        private List<PizzaOrder> BuildOrders(List<string> rawOrders)
        {
            if (rawOrders == null || rawOrders.Count == 0)
                throw new Exception("Please provide at least 1 order.");
            var orders = new List<PizzaOrder>();
            foreach (var rawOrder in rawOrders)
            {
                orders.Add(GetOrder(rawOrder));
            }
            return orders;
        }

        private PizzaOrder GetOrder(string rawOrder)
        {
            var orderList = rawOrder.Split(", ");
            var order = new PizzaOrder() { PizzaName = orderList[0] };
            order.ExtrasToAdd.AddRange(orderList.Skip(1).Where(o => !o.StartsWith('-')));
            order.ExtrasToRemove.AddRange(orderList.Skip(1).Where(o => o.StartsWith('-')).Select(o => o.TrimStart('-')));
            return order;
        }

        #endregion
    }
}
