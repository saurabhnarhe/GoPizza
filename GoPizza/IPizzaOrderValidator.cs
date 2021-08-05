using System.Collections.Generic;

namespace GoPizza
{
    public interface IPizzaOrderValidator
    {
        void Validate(List<PizzaOrder> orders);
    }
}