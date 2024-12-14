using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFleetDispatcher.Tests
{
    public class DispatcherTest
    {
        [Fact]
        public void AssingMissions_ShouldAssignShipsToOnePlanet_WhenShipsCanReachPlanets()
        {
            // Arrange
            var ship1 = new LongRangeShip("Ship1", 100);
            var ship2 = new MiddleRangeShip("Ship2", 50);
            var planet1 = new Planet { Name = "Planet1", X = 30, Y = 40, CargoDemand = 40 };  // дистанция 50
            var planet2 = new Planet { Name = "Planet2", X = 10, Y = 10, CargoDemand = 20 };  // 14.1
            var planet3 = new Planet { Name = "Planet3", X = 70, Y = 80, CargoDemand = 30 };  // 104.0

            var ships = new List<ASpaceship> { ship1, ship2 };
            var planets = new List<Planet> { planet1, planet2, planet3 };

            var dispatcher = new Dispatcher(ships, planets);

            // Act
            var assignments = dispatcher.AssingMissions();

            // Assert
            Assert.Equal(1, assignments[ship1].Count); 
        }
        [Fact]
        public void AssingMissions_ShouldNotAssignShips_WhenShipsCannotReachPlanets()
        {
            // Arrange
            var ship1 = new NearRangeShip("Ship1", 100);
            var ship2 = new MiddleRangeShip("Ship2", 50);
            var planet1 = new Planet { Name = "Planet1", X = 100, Y = 100, CargoDemand = 40 }; // 141.4
            var planet2 = new Planet { Name = "Planet2", X = 150, Y = 150, CargoDemand = 30 }; // 212.1

            var ships = new List<ASpaceship> { ship1, ship2 };
            var planets = new List<Planet> { planet1, planet2 };

            var dispatcher = new Dispatcher(ships, planets);

            // Act
            var assignments = dispatcher.AssingMissions();

            // Assert
            Assert.Empty(assignments[ship1]); 
            Assert.Empty(assignments[ship2]); 
        }
        [Fact]
        public void AssingMissions_ShouldAssignShipsOnCargoCapacity()
        {
            // Arrange
            var planets = new List<Planet>
            {
                new Planet { Name = "Planet1", X = 1, Y = 1, CargoDemand = 10 },
                new Planet { Name = "Planet2", X = 1, Y = 1, CargoDemand = 20 }
            };

            var ships = new List<ASpaceship>
            {
                new LongRangeShip("Ship1", 15),
                new MiddleRangeShip("Ship2", 25)
            };

            var dispatcher = new Dispatcher(ships, planets);

            // Act
            var assignments = dispatcher.AssingMissions();

            // Assert
            Assert.Equal(1, assignments[ships[0]].Count); 
            Assert.Equal(1, assignments[ships[1]].Count); 
        }

    }
}
