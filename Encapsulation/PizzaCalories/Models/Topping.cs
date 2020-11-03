using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const string InvalidTopping = "Cannot place {0} on top of your pizza.";
        private const string InvalidWeight = "{0} weight should be in the range [1..50].";


        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private string type;

        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(String.Format(InvalidTopping, value.ToString()));
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (1 > value || value > 50)
                {
                    throw new ArgumentException(String.Format(InvalidWeight, this.Type.ToString()));
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double currentCalories = GlobalCommons.BaseCalories * this.Weight;

            var typeModifier = 1.0;
            switch (this.type.ToLower())
            {
                case "meat":
                    typeModifier = Meat;
                    break;
                case "veggies":
                    typeModifier = Veggies;
                    break;
                case "cheese":
                    typeModifier = Cheese;
                    break;
                case "sauce":
                    typeModifier = Sauce;
                    break;
            }

            currentCalories *= typeModifier;
            return currentCalories;
        }
    }
}
