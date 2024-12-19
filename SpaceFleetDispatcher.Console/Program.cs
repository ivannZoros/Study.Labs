using System.Globalization;
using System.Numerics;

namespace SpaceFleetDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь файла с данными:");
            string fileName = Console.ReadLine();

            var ships = new List<ASpaceship>();
            var planets = new List<Planet>();
            bool isShipsSection = true;
            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    isShipsSection = false;
                    continue;
                }

                if (isShipsSection)
                {
                    ships.Add(ASpaceship.Parse(line));
                }
                else
                {
                    var planetData = line.Split("\t");
                    string name = planetData[0];
                    double x = double.Parse(planetData[1], CultureInfo.InvariantCulture);
                    double y = double.Parse(planetData[2], CultureInfo.InvariantCulture);
                    double cargoDemand = double.Parse(planetData[3], CultureInfo.InvariantCulture);

                    planets.Add(new Planet
                    {
                        Name = name,
                        X = x,
                        Y = y,
                        CargoDemand = cargoDemand
                    });
                }
            }


            var dispatcher = new Dispatcher(ships, planets);
            var assignments = dispatcher.AssingMissions();


            Console.WriteLine("План полетов:");
            foreach (var assignment in assignments)
            {
                Console.WriteLine($"Корабль {assignment.Key.Name} (Тип: {assignment.Key.GetType().Name}):");
                foreach (var planet in assignment.Value)
                {
                    double distance = planet.CalculateDistance();
                    Console.WriteLine($"  Планета: {planet.Name}, Расстояние: {distance:0.0}, Груз: {planet.CargoDemand}");
                }
            }
        }
    }
}
