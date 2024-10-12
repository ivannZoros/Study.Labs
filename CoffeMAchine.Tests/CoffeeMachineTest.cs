using Xunit;
using CoffeeMachineLibrary;

namespace CoffeMachine.Tests
{
    public class CoffeeMachineTest
        //Доделать тесты по CoffeeMachine
    {
        [Fact]
        public void LoadMilk_Success()
        {
            //Arrange
            int expectedMilk = 8;
            
            //Act
            var loadMilk = new CoffeeMachine().LoadMilk(expectedMilk);
            //Assert
            Assert.Equal(expectedMilk, loadMilk);
        }
    }
}
