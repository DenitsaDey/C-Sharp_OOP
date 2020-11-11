using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Exceptions;
using WildFarm.Factories;
using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private AnimalFactory animalFactory;
        private FoodFactory foodFactory;
        private ICollection<Animal> animals;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }
        
        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split();
                string type = cmdArgs[0];
                string name = cmdArgs[1];
                double weight = double.Parse(cmdArgs[2]);
                Animal currentAnimal = null;
                currentAnimal = this.animalFactory.GenerateAnimal(type, name, weight, cmdArgs);
                Console.WriteLine(currentAnimal.ProduceSound());

                string[] foodInfo = Console.ReadLine().Split();
                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);
                Food currentFood = this.foodFactory.GenerateFood(foodType, quantity);
                try
                {
                    currentAnimal.Feed(currentFood);
                }
                catch (UneatableFoodExc ufe)
                {
                    Console.WriteLine(ufe.Message);
                }
                this.animals.Add(currentAnimal);
            }

            if(animals.Count != 0)
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }
            }
        }
    }
}
