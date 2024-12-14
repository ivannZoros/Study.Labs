namespace SpaceFleetDispatcher.Tests
{
    public class ASpaceshipTests
    {
        [Fact]
        public void СanReach_ShouldReturnTrue_WhenPlanetIsWithinRangeAndCapacityIsSufficient()
        {
            // Arrange
            var ship = new LongRangeShip("TestShip", 100);
            var planet = new Planet { X = 3, Y = 4, CargoDemand = 50 }; // дистанция 50

            // Act
            var canReach = ship.СanReach(planet);

            // Assert
            Assert.True(canReach);
        }

        [Fact]
        public void СanReach_ShouldReturnFalse_WhenPlanetIsOutOfRange()
        {
            // Arrange
            var ship = new LongRangeShip("TestShip", 100);
            var planet = new Planet { X = 50, Y = 60, CargoDemand = 50 }; // 78

            // Act
            var canReach = ship.СanReach(planet);

            // Assert
            Assert.False(canReach);
        }
        [Fact]
        public void Parse_ShouldThrowException_WhenInputHasInvalidFormat()
        {
            // Arrange
            string invalidInput = "LongRangeShip 100";

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => ASpaceship.Parse(invalidInput));
            Assert.Equal("Формат некорректный", exception.Message);
        }

        [Fact]
        public void Parse_ShouldThrowException_WhenCapacityIsInvalid()
        {
            // Arrange
            string invalidInput = "LongRangeShip aaa PlanetX";

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => ASpaceship.Parse(invalidInput));
            Assert.Equal("Вместимость корабля неверная", exception.Message);
        }

        [Fact]
        public void Parse_ShouldReturnCorrectShip_WhenValidInput()
        {
            // Arrange
            string validInput = "LongRange 100 TestShip";

            // Act
            var ship = ASpaceship.Parse(validInput);

            // Assert
            Assert.IsType<LongRangeShip>(ship);
            Assert.Equal("TestShip", ship.Name);
            Assert.Equal(100, ship.Capacity);
        }

    }
}