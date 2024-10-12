namespace CoffeeMachineLibrary
{
    public class BrewingUnit
    {
        public Coffee Brew(GroundCoffee groundCoffee,RecipeNames recipename) 
            // GroundCoffee groundCoffee для чего нужен?Есть в диаграмме класса
        {
            return new Coffee(recipename);
        }
    }
}
