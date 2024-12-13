namespace SpaceFleetDispatcher
{
    public class Planet
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double CargoDemand { get; set; }

        public double CalculateDistance()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

    }
}
