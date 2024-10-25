using Xunit;
using CoffeeMachineLibrary;
using System.ComponentModel;
using System;

namespace CoffeMachine.Tests
{
    public class CoffeeMachineTest
    {
        [Fact]
        public void LoadMilk_Success()
        {
            //Arrange
            int expectedMilk = 50;
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
        [Fact]
        public void GetMilkLevel_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            int initialMilk = coffeeMachine.GetMilkLevel(); 
            int addedMilk = 100;
            coffeeMachine.LoadMilk(addedMilk);

            //Act
            int actualMilk = coffeeMachine.GetMilkLevel();

            //Assert
            Assert.Equal(initialMilk + addedMilk, actualMilk);
        }
        [Fact]
        public void GetWaterLevel_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            int initialWater = coffeeMachine.GetWaterLevel();
            int addedWater = 100;
            coffeeMachine.LoadWater(addedWater);

            //Act
            int actualWater = coffeeMachine.GetWaterLevel();

            //Assert
            Assert.Equal(initialWater + addedWater, actualWater);
        }
        [Fact]
        public void GetBeansLevel_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            int initialBeans = coffeeMachine.GetBeansLevel();
            int addedBeans = 100;
            coffeeMachine.LoadBeans(addedBeans);

            //Act
            int actualBeans = coffeeMachine.GetBeansLevel();

            //Assert
            Assert.Equal(initialBeans + addedBeans, actualBeans);
        }
        [Fact]
        public void Brew_Cappuccino_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadBeans(50);
            coffeeMachine.LoadWater(50);
            //Act
            var coffee = coffeeMachine.Brew(RecipeNames.Cappuccino);
            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(RecipeNames.Cappuccino, coffee.Recipe);
        }
        [Fact]
        public void Brew_Filtered_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadBeans(50);
            coffeeMachine.LoadWater(50);
            //Act
            var coffee = coffeeMachine.Brew(RecipeNames.Filtered);
            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(RecipeNames.Filtered, coffee.Recipe);
        }
        [Fact]
        public void Brew_Espresso_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadBeans(50);
            coffeeMachine.LoadWater(50);
            //Act
            var coffee = coffeeMachine.Brew(RecipeNames.Espresso);
            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(RecipeNames.Espresso, coffee.Recipe);
        }

    }

    
}
