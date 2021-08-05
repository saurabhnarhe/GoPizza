using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace GoPizza.Fixture
{
    public class PizzaBillCalculatorFixture
    {
        [Fact]
        public void ShouldThrowExceptionWhenEmptyOrder()
        {
            var mockValidator = new Mock<IPizzaOrderValidator>();
            var mockPizzaCostCalculator = new Mock<IPizzaCostCalculator>();
            var pizzaBillCalculator = new PizzaBillCalculator(mockValidator.Object, mockPizzaCostCalculator.Object);
            var emptyOrders = new List<string>() { };

            var exception = Assert.Throws<Exception>(() => pizzaBillCalculator.GetBill(emptyOrders));
            Assert.Equal("Please provide at least 1 order.", exception.Message);
        }

        [Fact]
        public void ShouldReturnTotalPrice()
        {
            // Arrange
            var expectedBill = 100;

            var mockValidator = new Mock<IPizzaOrderValidator>();
            mockValidator
                .Setup(v => v.Validate(It.IsAny<List<PizzaOrder>>()));

            var mockPizzaCostCalculator = new Mock<IPizzaCostCalculator>();
            mockPizzaCostCalculator
                .Setup(c => c.GetCost(It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<List<string>>()))
                .Returns(expectedBill);

            var billCalculator = new PizzaBillCalculator(mockValidator.Object, mockPizzaCostCalculator.Object);

            var orders = new List<string>() { "Double Chicken feast, cheese, cottage cheese, olives, Thin Crust, -onion" };

            // Act
            var bill = billCalculator.GetBill(orders);

            // Assert
            Assert.Equal(expectedBill, bill);
            mockValidator
                .Verify(v => v.Validate(It.IsAny<List<PizzaOrder>>()), Times.Once);
            mockPizzaCostCalculator
                .Verify(c => c.GetCost(It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<List<string>>()), Times.Once);
        }
    }
}
