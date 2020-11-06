using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Identifiable> society = new List<Identifiable>();
            
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                if(info.Length == 2)
                {
                    Identifiable robot = new Robot(info[0], info[1]);
                    society.Add(robot);
                }
                else if(info.Length == 3)
                {
                    Identifiable citizen = new Citizen(info[0], info[1], info[2]);
                    society.Add(citizen);
                }
            }
            string fakeID = Console.ReadLine();
            List<Identifiable> detained = society.Where(i => i.Id.EndsWith(fakeID)).ToList();
            foreach (var element in detained)
            {
                Console.WriteLine(element.Id);
            }
        }
    }
}
