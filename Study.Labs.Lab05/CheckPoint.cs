using System;
using System.Collections.Generic;

namespace Study.Labs.Lab05
{
    class CheckPoint
    {
        private List<String> _stolenNumbers = new List<String>();
        private CheckPointStatistics _statistics = new CheckPointStatistics();

        public void RegisterVehicle(AVehicle vehicle)
        {
            
            CreateList(_stolenNumbers);
            HasStolenPlate(vehicle);
            if (vehicle.GetSpeed() > 110)
            {
                Console.WriteLine("Превышение скорости");
                _statistics.SpeedLimitBreakersCount++;
            }
            if (HasStolenPlate(vehicle) == true)
            {
                Console.WriteLine("Перехват!");
                _statistics.CarJackersCount++;
            }
            Console.WriteLine($"Цвет {vehicle.Color}\nКузов {vehicle.BodyType}\nПасскажир {vehicle.HasPassanger}\nСкорость {vehicle.GetSpeed()}\n********");
            
        }
        private static List<String> CreateList(List<String> _stolenNumbers)
        {
            for (int i = 0;i < 51;i++){
                Random rng = new Random();
                int plate = rng.Next(100, 1000);
                _stolenNumbers.Add(plate.ToString());
            }
            return _stolenNumbers;
        }
        private bool HasStolenPlate(AVehicle vehicle)
        {
            for (int i = 0; i < _stolenNumbers.Count; i++)
            {
                bool HasStolenPlate = _stolenNumbers.Contains(vehicle.Plate);
                return HasStolenPlate;
            }
            return false;
        }
        public CheckPointStatistics GetStatistics()
        {
            CheckPointStatistics statistics = new CheckPointStatistics();
            
            return _statistics;
        }
    }
}
