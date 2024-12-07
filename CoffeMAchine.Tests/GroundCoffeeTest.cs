using CoffeeMachineLibrary;
using Xunit;

namespace CoffeMachineLibrary.Tests
{
    public class GroundCoffeeTest
    {
        [Fact]
        public void GroundCoffee_Success()
        {
            //Arrange
            const int expectedGround = 4;

            //Act
            var ground = new GroundCoffee(expectedGround);

            //Assert
            Assert.NotNull(ground);
            Assert.Equal(expectedGround, ground.Quantity);
        }
    }
}
