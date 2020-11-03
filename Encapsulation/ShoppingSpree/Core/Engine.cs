using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        //Purpose is to:
        //Read data from the console
        //Process data -> manipulate data, save to db, etc.
        //Print data on the console

        private readonly ICollection<Person> people;

        private readonly ICollection<Product> availableProducts;

        public Engine()
        {
            this.people = new List<Person>();
            this.availableProducts = new List<Product>();
        }

        public void Run()
        {
            //Place business logic here
            try
            {
                ParsePeopleInput();
                ParseProductInput();

                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] purchase = input.Split();
                    Person currentPerson = this.people.FirstOrDefault(s => s.Name == purchase[0]);
                    Product currentProduct = this.availableProducts.FirstOrDefault(p => p.Name == purchase[1]);
                    if (currentPerson != null && currentProduct != null)
                    {
                        currentPerson.BuyProduct(currentProduct);
                    }
                }

                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

        private void ParseProductInput()
        {
            string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < products.Length; i++)
            {
                string[] productInfo = products[i].Split("=");
                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                Product product = new Product(name, cost);
                this.availableProducts.Add(product);
            }
        }


        private void ParsePeopleInput()
        {
            string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < people.Length; i++)
            {
                string[] personInfo = people[i].Split("=");
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }
    }
}


