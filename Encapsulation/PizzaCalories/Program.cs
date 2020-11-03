using PizzaCalories.Models;
using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string pizzaName = pizzaInput[1];

                string[] doughInput = Console.ReadLine().Split();
                string flourType = doughInput[1];
                string bakingTechnique = doughInput[2];
                double doughWeight = double.Parse(doughInput[3]);

                Dough myDough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza myPizza = new Pizza(pizzaName, myDough);

                string toppingInput = string.Empty;
                while ((toppingInput = Console.ReadLine()) != "END")
                {
                    string[] toppings = toppingInput.Split();
                    string toppingType = toppings[1];
                    double toppingWeight = double.Parse(toppings[2]);

                    Topping currentTopping = new Topping(toppingType, toppingWeight);
                    myPizza.AddToppings(currentTopping);
                }
                Console.WriteLine($"{myPizza.Name} - {myPizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }




        }
    }
}
