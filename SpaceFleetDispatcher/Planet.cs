namespace SpaceFleetDispatcher
{
    public class Planet
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double CargoDemand { get; set; }

        private readonly double EarthX = 1.0;
        private readonly double EarthY = -0.4;

        public double CalculateDistance()
        {
            return Math.Sqrt(Math.Pow(X - EarthX, 2) + Math.Pow(Y - EarthY, 2));
        }

    }
}
