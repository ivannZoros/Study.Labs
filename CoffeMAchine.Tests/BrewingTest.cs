using Xunit;
using CoffeeMachineLibrary;

namespace CoffeMachine.Tests
{
    public class BrewingTest
    {
        [Fact]
        public void Brew_ReturnsCorrectCoffeeWithRecipe()
        {
            //Arrange
            int expectedQuantity = 8;
            RecipeNames expextedRecipe = RecipeNames.Espresso;
            var brewingUnit = new BrewingUnit();
            var groundCoffee = new GroundCoffee(expectedQuantity);
            //Act
            var coffee = brewingUnit.Brew(groundCoffee, expextedRecipe);
            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(expextedRecipe, coffee.Recipe);
        }

    }
}
