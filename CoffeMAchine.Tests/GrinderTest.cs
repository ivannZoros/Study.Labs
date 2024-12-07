using Xunit;
using CoffeeMachineLibrary;

namespace CoffeMachineLibrary.Tests
{
    public class GrinderTest
    {
        [Fact]
        public void Grind_ReturnsNotEmptyResultWithQantity()
        {
            //Arrange
            const int expectedGrind = 4;
            var grinder = new GrinderUnit();

            //Act
            var groundCoffee = grinder.Grind(expectedGrind);
            //Assert
            Assert.NotNull(groundCoffee);
            Assert.Equal(expectedGrind, groundCoffee.Quantity);
        }
    }
}
