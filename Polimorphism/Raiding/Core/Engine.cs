using Raiding.Common;
using Raiding.Core.Contracts;
using Raiding.Factory;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<BaseHero> raidGroup;

        private HeroFactory heroFactory;

        public Engine()
        {
            this.raidGroup = new List<BaseHero>();
            this.heroFactory = new HeroFactory();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while (n > this.raidGroup.Count)
            {
                
                BaseHero currentHero = null;
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();
                    currentHero = this.heroFactory.ProduceHero(heroType, heroName);
                    this.raidGroup.Add(currentHero);
                }
                catch (ArgumentException em)
                {
                    Console.WriteLine(em.Message);
                    continue;
                }

            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesTotalPower = 0;

            if (this.raidGroup.Count != 0)
            {
                foreach (var bhero in raidGroup)
                {
                    Console.WriteLine(bhero.CastAbility());
                }
                heroesTotalPower = raidGroup.Sum(h => h.Power);
            }


            Console.WriteLine((heroesTotalPower >= bossPower) ?
            "Victory!" : "Defeat...");

        }
    }
}
