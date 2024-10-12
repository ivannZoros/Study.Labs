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
            const int expectedCapacity = 1000;
            var container = new Container(expectedCapacity);
            const int loadValue = 500;
            // Act
            container.LoadResourse(loadValue);
            var actualCapacity = container.GetCapacity;
            // Assert
            Assert.Equal(loadValue, actualCapacity);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(1001)]
        public void LoadResourseInvalidValue_ThrowException(int loadValue)
        {
            //Arrange 
            var container = new Container(1000);    
            //Act + Assert
            Assert.Throws<ArgumentException>(() => container.LoadResourse(loadValue));
        }
        [Fact]
        public void GetResoure_Success()
        {
            // Arrange
            const int expectedCapacity = 1000;
            var container = new Container(expectedCapacity);
            const int getValue = 500;
            // Act
            container.LoadResourse(getValue);
            var actualCapacity = container.GetCapacity;
            // Assert
            Assert.Equal(getValue, actualCapacity);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(1001)]
        public void GetResourseInvalidValue_ThrowException(int getValue)
        {
            //Arrange 
            var container = new Container(1000);
            //Act + Assert
            Assert.Throws<ArgumentException>(() => container.GetResourse(getValue));
        }
    }

}
