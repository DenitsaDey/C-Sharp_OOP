using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] details = Console.ReadLine().Split();
                string name = details[0];
                int age = int.Parse(details[1]);
                string gender = details[2];

                try
                {
                    switch (input.Trim())
                    {
                        case "Dog":
                            Animal dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Cat":
                            Animal cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Frog":
                            Animal frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Kittens":
                            Animal kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            Animal tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var pet in animals)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(pet.GetType().Name);
                sb.AppendLine(pet.ToString());
                sb.AppendLine(pet.ProduceSound());
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
