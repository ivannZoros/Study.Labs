namespace SpaceFleetDispatcher
{
    public class LongRangeShip : ASpaceship
    {
        public LongRangeShip(string name, int capacity)
          : base(name, capacity) { }

        public override double GetRange() => 60.0;
    }

    public class MiddleRangeShip : ASpaceship
    {
        public MiddleRangeShip(string name, int capacity)
          : base(name, capacity) { }

        public override double GetRange() => 12.0;
    }

    public class NearRangeShip : ASpaceship
    {
        public NearRangeShip(string name, int capacity)
          : base(name, capacity) { }

        public override double GetRange() => 4.0;
    }
}
