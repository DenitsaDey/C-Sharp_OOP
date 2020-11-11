using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string UneatableFoodMessage = "{0} does not eat {1}!";


        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }


        public abstract ICollection<Type> PreferredFood { get; }
        public abstract double WeightMultiplier { get; }
        public abstract string ProduceSound();


        public void Feed(IFood food)
        {
            if (!this.PreferredFood.Contains(food.GetType()))
            {
                throw new UneatableFoodExc(String.Format(UneatableFoodMessage, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

    }
}
