using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal GenerateAnimal(string type, string name, double weight, string[] cmdArgs)
        {
            Animal animal = null;
            switch (type)
            {
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(cmdArgs[3]));
                    break;
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(cmdArgs[3]));
                    break;
                case "Cat":
                    animal = new Cat(name, weight, cmdArgs[3], cmdArgs[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, cmdArgs[3], cmdArgs[4]);
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, cmdArgs[3]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, cmdArgs[3]);
                    break;             
            }
           
            return animal;
        }
    }
}
