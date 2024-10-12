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
            

        public CoffeeMachine() {
            _recipes[RecipeNames.Cappuccino] = new Recipe(3, 6, 5);
            _recipes[RecipeNames.Filtered] = new Recipe(1, 1, 7);
            _recipes[RecipeNames.Espresso] = new Recipe(0, 2, 9);
            _beansContainer = new Container(100);
            _waterContainer = new Container(500);
            _milkContainer = new Container(200);
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
            _waterContainer.GetResourse(recipe.Water);
            _milkContainer.GetResourse(recipe.Milk);
            _beansContainer.GetResourse(recipe.Beans);

            GroundCoffee groundCoffee = _grinderUnit.Grind(recipe.Beans);
            return _brewingUnit.Brew(groundCoffee,recipeName); 
        }

        public int LoadWater(int value)
        {
            return _waterContainer.LoadResourse(value);
        }public int LoadMilk(int value)
        {
            return _milkContainer.LoadResourse(value);
        }public int LoadBeans(int value)
        {
            return _beansContainer.LoadResourse(value);
        }

        public int GetWaterLevel()
        {
            return _waterContainer.GetValue;
        }
        public int GetMilkLevel()
        {
            return _milkContainer.GetValue;
        }
        public int GetBeansLevel() 
        {
            return _beansContainer.GetValue;
        }
    }
}
