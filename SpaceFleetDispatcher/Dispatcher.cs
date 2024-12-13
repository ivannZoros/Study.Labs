namespace SpaceFleetDispatcher
{
    public class Dispatcher
    {
        private readonly List<ASpaceship> _ships;
        private readonly List<Planet> _planets;
        public Dispatcher(List<ASpaceship> ships, List<Planet> planets)
        {
            _ships = ships;
            _planets = planets;
        }

        public Dictionary<ASpaceship,List<Planet>> AssingMissions()
        {
            var assignments = new Dictionary<ASpaceship, List<Planet>>();
            var remainingPlanets = new List<Planet>(_planets);
            foreach (var ship in _ships)
            {
                assignments[ship] = new List<Planet>();
                foreach (var planet in remainingPlanets.ToList())
                {
                    if (ship.СanReach(planet))
                    {
                        assignments[ship].Add(planet);
                        remainingPlanets.Remove(planet);
                        break;
                    }
                }
            }
            return assignments;
        }
    }
}
