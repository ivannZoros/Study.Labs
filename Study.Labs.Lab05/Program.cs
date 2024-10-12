using System;

namespace Study.Labs.Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckPoint checkPoint = new CheckPoint();
            CheckPointStatistics statistics = checkPoint.GetStatistics();
            while (!Console.KeyAvailable)
            {
                
                System.Threading.Thread.Sleep(2000);
                Random random = new Random();
                int rnd = random.Next(3);

                
                if (rnd == 0)
                {
                    new Car();
                    checkPoint.RegisterVehicle(new Car());
                    checkPoint.GetStatistics();
                    statistics.CarCount++;
                }
                else if (rnd == 1)
                {
                    checkPoint.RegisterVehicle(new Truck());
                    checkPoint.GetStatistics();
                    statistics.TrucksCount++;
                }
                else
                {
                    checkPoint.RegisterVehicle(new Bus());
                    checkPoint.GetStatistics();
                    statistics.BusesCount++;

                }

            }

            Console.WriteLine($"Количество машин {statistics.CarCount}\nКоличество автобусов {statistics.BusesCount}\n" +
                $"Количество грузовиков {statistics.TrucksCount}\n" +
                $"Количество нарушений скорости {statistics.SpeedLimitBreakersCount}\n" +
                $"Количество угнанных машин {statistics.CarJackersCount}");
        }
    }
}
