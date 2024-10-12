namespace CoffeeMachineLibrary
{
    public class Recipe
    {
        public int Water { get; }
        public int Milk { get; }
        public int Beans { get; }

        public Recipe(int water, int milk, int beans)
        {
            Water = water;
            Milk = milk;
            Beans = beans;
        }
    }
}
