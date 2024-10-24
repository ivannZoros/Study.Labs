using Xunit;
using CoffeeMachineLibrary;
using System.ComponentModel;
using System;

namespace CoffeMachine.Tests
{
    public class CoffeeMachineTest
        //Доделать тесты по CoffeeMachine Get...
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
        [Fact]
        public void LoadMilk_MoreThanPossible()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            //Act + Assert
            Assert.Throws<ArgumentException>(() => coffeeMachine.LoadMilk(201));


        }


        [Fact]
        public void LoadWater_Success()
        {
            //Arrange
            int expectedWater = 8;
            //Act
            var loadWater = new CoffeeMachine().LoadWater(expectedWater);
            //Assert
            Assert.Equal(expectedWater, loadWater);
        }
        [Fact]
        public void LoadWater_MoreThanPossible()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            //Act + Assert
            Assert.Throws<ArgumentException>(() => coffeeMachine.LoadWater(501));
        }
        
        
        [Fact]
        public void LoadBeans_Success()
        {
            //Arrange
            int expectedBeans = 8;
            //Act
            var loadBeans = new CoffeeMachine().LoadBeans(expectedBeans);
            //Assert
            Assert.Equal(expectedBeans, loadBeans);
        }
        [Fact]
        public void LoadBeans_MoreThanPossible()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            //Act + Assert
            Assert.Throws<ArgumentException>(() => coffeeMachine.LoadBeans(101));
        }
    }

    
}
