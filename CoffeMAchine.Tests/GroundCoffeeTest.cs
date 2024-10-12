using CoffeeMachineLibrary;
using Xunit;

namespace CoffeMachine.Tests
{
    public class GroundCoffeeTest
    {
        [Fact]
        public void GroundCoffee_Success()
        {
            //Arrange + Act
            const int expectedGround = 4;
            var ground = new GroundCoffee(expectedGround);

            //Assert
            Assert.NotNull(ground);
            Assert.Equal(expectedGround, ground.Quantity);
        }
    }
}
