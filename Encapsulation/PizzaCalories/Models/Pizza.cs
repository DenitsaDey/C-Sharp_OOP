using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const int NumberOfToppings = 10;
        
        private string name;

        private ICollection<Topping> toppings;

        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
            TotalCalories += dough.CalculateCalories();
        }

        public string Name {
            get => this.name;
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public double TotalCalories { get; set; }

        public void AddToppings(Topping topping)
        {
            if (this.toppings.Count >= NumberOfToppings)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);

            TotalCalories += topping.CalculateCalories();
        }

    }
}
