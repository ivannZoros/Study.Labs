using Xunit;
using System;

namespace CoffeeMachineLibrary.Tests
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
 
            int addedMilk1 = 10;
            int addedMilk2 = 20;
            coffeeMachine.LoadMilk(addedMilk1);
            coffeeMachine.LoadMilk(addedMilk2);
            //Act
            int actualMilk = coffeeMachine.GetMilkLevel();
            //Assert
            Assert.Equal(addedMilk2 + addedMilk1, actualMilk);
        }
        [Fact]
        public void GetWaterLevel_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            int addedWater1 = 10;
            int addedWater2 = 15;
            coffeeMachine.LoadWater(addedWater1);
            coffeeMachine.LoadWater(addedWater2);
            //Act
            int actualWater = coffeeMachine.GetWaterLevel();
            //Assert
            Assert.Equal(addedWater2 + addedWater1, actualWater);
        }
        [Fact]
        public void GetBeansLevel_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            
            int addedBeans1 = 10;
            int addedBeans2 = 50;
            coffeeMachine.LoadBeans(addedBeans1);
            coffeeMachine.LoadBeans(addedBeans2);
            //Act
            int actualBeans = coffeeMachine.GetBeansLevel();
            //Assert
            Assert.Equal(addedBeans1 + addedBeans2, actualBeans);
        }
        [Fact]
        public void Brew_Cappuccino_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadWater(50);
            coffeeMachine.LoadBeans(50);

            //Act
            var coffee = coffeeMachine.Brew(RecipeNames.Cappuccino);

            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(RecipeNames.Cappuccino, coffee.Recipe);
        }
        [Fact]
        public void Brew_Espresso_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadWater(50);
            coffeeMachine.LoadBeans(50);

            //Act
            var coffee = coffeeMachine.Brew(RecipeNames.Espresso);

            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(RecipeNames.Espresso, coffee.Recipe);
        }
        [Fact]
        public void Brew_Filtered_Success()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadWater(50);
            coffeeMachine.LoadBeans(50);

            //Act
            var coffee = coffeeMachine.Brew(RecipeNames.Filtered);

            //Assert
            Assert.NotNull(coffee);
            Assert.Equal(RecipeNames.Filtered, coffee.Recipe);
        }
        [Fact]
        public void Brew_Filtered_TakesResourse()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadWater(50);
            coffeeMachine.LoadBeans(50);
            var milk = coffeeMachine.GetMilkLevel();
            var beans = coffeeMachine.GetMilkLevel();
            var water = coffeeMachine.GetMilkLevel();
            //Act
            coffeeMachine.Brew(RecipeNames.Filtered);
            var actualmilk = coffeeMachine.GetMilkLevel();
            var actualbeans = coffeeMachine.GetBeansLevel();
            var actualwater = coffeeMachine.GetWaterLevel();
            //Assert
            Assert.Equal(milk - 1, actualmilk);
            Assert.Equal(beans - 7, actualbeans);
            Assert.Equal(water - 1, actualwater);
        }
        [Fact]
        public void Brew_Espresso_TakesResourse()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadWater(50);
            coffeeMachine.LoadBeans(50);
            var milk = coffeeMachine.GetMilkLevel();
            var beans = coffeeMachine.GetMilkLevel();
            var water = coffeeMachine.GetMilkLevel();
            //Act
            coffeeMachine.Brew(RecipeNames.Espresso);
            var actualmilk = coffeeMachine.GetMilkLevel();
            var actualbeans = coffeeMachine.GetBeansLevel();
            var actualwater = coffeeMachine.GetWaterLevel();
            //Assert
            Assert.Equal(milk, actualmilk);
            Assert.Equal(beans - 9, actualbeans);
            Assert.Equal(water - 2, actualwater);
        }
        [Fact]
        public void Brew_Cappuccino_TakesResourse()
        {
            //Arrange
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.LoadMilk(50);
            coffeeMachine.LoadWater(50);
            coffeeMachine.LoadBeans(50);
            var milk = coffeeMachine.GetMilkLevel();
            var beans = coffeeMachine.GetMilkLevel();
            var water = coffeeMachine.GetMilkLevel();
            //Act
            coffeeMachine.Brew(RecipeNames.Cappuccino);
            var actualmilk = coffeeMachine.GetMilkLevel();
            var actualbeans = coffeeMachine.GetBeansLevel();
            var actualwater = coffeeMachine.GetWaterLevel();
            //Assert
            Assert.Equal(milk - 8, actualmilk);
            Assert.Equal(beans - 8, actualbeans);
            Assert.Equal(water - 8, actualwater);
        }
        [Fact]
        public void Brew_WithoutResourceThrowsException()
        {
            //Arrange 
            var coffeeMachine = new CoffeeMachine();
            //act + assert
            Assert.Throws<ArgumentException>(() => coffeeMachine.Brew(RecipeNames.Espresso));
        }
    }
}


