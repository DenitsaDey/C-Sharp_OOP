using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const string InvalidDough = "Invalid type of dough.";
        private const string InvalidWeight = "Dough weight should be in the range [1..200].";
        
        private const double White = 1.5;
        private const double Wholegrain = 1;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1;

        private string flourType;

        private string bakingTechnique;

        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(String.Format(InvalidDough));
                }
                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(String.Format(InvalidDough));
                }
                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (0 > value || value > 200)
                {
                    throw new ArgumentException(String.Format(InvalidWeight));
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double currentCalories = GlobalCommons.BaseCalories * this.Weight;

            var flourTypemodifier = 1.0;
            switch (this.FlourType)
            {
                case "white":
                    flourTypemodifier = White;
                    break;
                case "wholegrain":
                    flourTypemodifier = Wholegrain;
                    break;
            }

            var bakingTechniqueModifier = 1.0;
            switch (this.BakingTechnique)
            {
                case "crispy":
                    bakingTechniqueModifier = Crispy;
                    break;
                case "chewy":
                    bakingTechniqueModifier = Chewy;
                    break;
                case "homemade":
                    bakingTechniqueModifier = Homemade;
                    break;
            }

            currentCalories *= flourTypemodifier * bakingTechniqueModifier;
            return currentCalories;
        }
    }
}
