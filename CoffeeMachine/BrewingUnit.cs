namespace CoffeeMachineLibrary
{
    public class BrewingUnit
    {
        public Coffee Brew(GroundCoffee groundCoffee,RecipeNames recipename) 
        {
            return new Coffee(recipename);
        }
    }
}
