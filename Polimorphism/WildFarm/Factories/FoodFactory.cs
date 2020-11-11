using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food GenerateFood(string type, int quantity)
        {
            Food food = null;
            switch (type)
            {
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }
            return food;
        }
    }
}
