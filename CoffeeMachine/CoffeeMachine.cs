using System;
using System.Collections.Generic;

namespace CoffeeMachineLibrary
{
    public class CoffeeMachine
    {
        private Dictionary<RecipeNames, Recipe> _recipes;
        private GrinderUnit _grinderUnit;
        private BrewingUnit _brewingUnit;
        private Container _waterContainer;
        private Container _milkContainer;
        private Container _beansContainer;


        public CoffeeMachine()
        {
            _recipes = new Dictionary<RecipeNames, Recipe>
            {
                [RecipeNames.Cappuccino] = new Recipe(8, 8, 8),
                [RecipeNames.Filtered] = new Recipe(1, 1, 7),
                [RecipeNames.Espresso] = new Recipe(0, 2, 9)
            };


            _beansContainer = new Container(100);
            _waterContainer = new Container(500);
            _milkContainer = new Container(200);

            _grinderUnit = new GrinderUnit();
            _brewingUnit = new BrewingUnit();
        }
        public Coffee Brew(RecipeNames recipeName)
        {
            Recipe recipe = _recipes[recipeName];
            
            if (GetBeansLevel() < recipe.Beans 
                || GetWaterLevel() < recipe.Water 
                || GetMilkLevel() < recipe.Milk)
            {
                throw new ArgumentException("Недостаточно ингредиентов");
            }
            _waterContainer.GetResource(recipe.Water);
            _milkContainer.GetResource(recipe.Milk);
            _beansContainer.GetResource(recipe.Beans);

            GroundCoffee groundCoffee = _grinderUnit.Grind(recipe.Beans);
            return _brewingUnit.Brew(groundCoffee,recipeName); 
        }

        public int LoadWater(int value)
        {
            return _waterContainer.LoadResource(value);
        }
        public int LoadMilk(int value)
        {
            return _milkContainer.LoadResource(value);
        }public int LoadBeans(int value)
        {
            return _beansContainer.LoadResource(value);
        }

        public int GetWaterLevel()
        {
            return _waterContainer.GetValue();
        }
        public int GetMilkLevel()
        {
            return _milkContainer.GetValue();
        }
        public int GetBeansLevel() 
        {
            return _beansContainer.GetValue();
        }
    }
}
