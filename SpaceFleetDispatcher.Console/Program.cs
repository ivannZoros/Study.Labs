namespace SpaceFleetDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new[] {
      "LongRange  30  Amigo",
      "MiddleRange  60  Fargo",
      "NearRange  100  Chipmunk"
     };

            foreach (var line in data)
                Console.WriteLine(ASpaceship.Parse(line));
        }
    }

}