using Study.Labs.Lab04.Entities;
using System;

namespace Study.Labs.Lab04.Helpers
{
    static class TrainHelper
    {
        public static Train FindTrain(Train[] trains, string number)
        {
            foreach (var train in trains)
            {
                if (train.Number == number)
                    return train;
            }

            return null;
        }

        public static void PrintTrain(Train train)
        {
            if (train == null)
                Console.WriteLine($"Поезд отсутствует");
            else
                Console.WriteLine($"Поезд №{train.Number}\nПункт назначения {train.DestinationPoint}\nПункт отправления {train.DeparturePoint}\nКол-во мест{train.NumberOfSeats}");
        }

        public static Train FindMaxSeatsTrain(Train[] trains)
        {
            Train result = trains[0];
            for (var i = 1; i < trains.Length; i++)
            {
                var currentTrain = trains[i];

                if (currentTrain.NumberOfSeats > result.NumberOfSeats)
                {
                    result = currentTrain;
                }
            }
            return result;
        }
    }
}
