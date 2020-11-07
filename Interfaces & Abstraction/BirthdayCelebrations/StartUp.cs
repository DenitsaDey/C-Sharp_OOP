using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBithdateable> society = new List<IBithdateable>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                if (input.StartsWith("Pet"))
                {
                    IBithdateable pet = new Pet(info[1], info[2]);
                    society.Add(pet);
                }
                else if (input.StartsWith("Citizen"))
                {
                    IBithdateable citizen = new Citizen(info[1], info[2], info[3], info[4]);
                    society.Add(citizen);
                }
            }
            string year = Console.ReadLine();
            List<IBithdateable> celebrated = society.Where(i => i.Birthdate.EndsWith(year)).ToList();

            foreach (var element in celebrated)
            {
                Console.WriteLine(element.Birthdate);
            }

        }
    }
}
