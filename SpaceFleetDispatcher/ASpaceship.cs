namespace SpaceFleetDispatcher
{
    abstract class ASpaceship
    {
        public string Name { get; protected set; }
        public int Capacity { get; protected set; }

        public ASpaceship(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public static ASpaceship Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("Входные данные пусты");

            var chunks = input.Split(
              new[] { "\t", " " },
              StringSplitOptions.RemoveEmptyEntries);
            int capacity;

            if (chunks.Length != 3)
                throw new Exception("Формат некорректный");
            if (!int.TryParse(chunks[1], out capacity) || capacity < 0)
                throw new Exception("Вместимость корабля неверная");

            var shipType = chunks[0];
            var name = chunks[2];

            if (shipType.Equals(
                "LongRange",
                StringComparison.InvariantCultureIgnoreCase))
                return new LongRangeShip(name, capacity);
            if (shipType.Equals(
                "MiddleRange",
                StringComparison.InvariantCultureIgnoreCase))
                return new MiddleRangeShip(name, capacity);
            if (shipType.Equals(
                "NearRange",
                StringComparison.InvariantCultureIgnoreCase))
                return new NearRangeShip(name, capacity);

            throw new Exception($"Тип {shipType} не поддерживается");
        }

        public override string ToString() =>
          $"Корабль \"{Name}\", "
            + $"вместимость: {Capacity}, "
            + $"дальность хода: {GetRange()}";

        public abstract double GetRange();
    }

}
