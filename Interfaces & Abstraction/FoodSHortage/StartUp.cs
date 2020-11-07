using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IPerson> society = new List<IPerson>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(data.Length == 4)
                {
                    IPerson citizen = new Citizen(data[0], data[1], data[2], data[3]);
                    society.Add(citizen);
                }
                else if(data.Length == 3)
                {
                    IPerson rebel = new Rebel(data[0], data[1], data[2]);
                    society.Add(rebel);
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var curentBuyer = society.FirstOrDefault(c => c.Name == input);
                if (curentBuyer != null)
                {
                    curentBuyer.BuyFood();
                }
            }
            Console.WriteLine(society.Sum(p=>p.Food));
             
        }
    }
}
