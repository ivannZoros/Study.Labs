using System;
using Xunit;
using CoffeeMachineLibrary;

namespace CoffeMachine.Tests
{
    public class ContainerTest
    {
        [Fact]
        public void ContainerCapacitySet_Success()
        {
            //Arrange
            const int expectedCapacity = 1000;
            var container = new Container(expectedCapacity);
            //Act
            var actualCapacity = container.Capacity;
            //Assert
            Assert.Equal(expectedCapacity, actualCapacity);

        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3001)]
        public void ContainerInvalidCapacity_ThrowsException(int capacity)
        {
            //Act + Assert
            Assert.Throws<ArgumentException>(() => new Container(capacity));

        }
        [Fact]
        public void LoadResource_Success()
        {
            // Arrange
            const int ñapacity = 100;
            var container = new Container(ñapacity);
            const int loadValue = 50;
            // Act
            container.LoadResource(loadValue);
            var actualValue = container.GetValue();
            // Assert
            Assert.Equal(loadValue, actualValue);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(1001)]
        public void LoadResourseInvalidValue_ThrowException(int loadValue)
        {
            //Arrange 
            var container = new Container(1000);    
            //Act + Assert
            Assert.Throws<ArgumentException>(() => container.LoadResource(loadValue));
        }
        [Fact]
        public void GetResourñe_Success()
        {
            // Arrange
            const int expectedCapacity = 1000;
            var container = new Container(expectedCapacity);
            const int initialValue = 500;
            container.LoadResource(initialValue);
            const int getValue = 200;
            // Act
            container.GetResource(getValue);
            var actualValue = container.GetValue();
            // Assert
            Assert.Equal(initialValue-getValue, actualValue);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(1001)]
        public void GetResourseInvalidValue_ThrowException(int getValue)
        {
            //Arrange 
            var container = new Container(1000);
            //Act + Assert
            Assert.Throws<ArgumentException>(() => container.GetResource(getValue));
        }
    }

}
