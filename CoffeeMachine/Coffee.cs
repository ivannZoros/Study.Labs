namespace CoffeeMachineLibrary
{
    public class Coffee
    {
        public RecipeNames Recipe { get; }

        public Coffee(RecipeNames recipe)
        {

            Recipe = recipe;
            
        }
    }
}
