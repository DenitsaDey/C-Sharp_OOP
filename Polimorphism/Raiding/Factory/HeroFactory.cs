using Raiding.Common;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factory
{
    public class HeroFactory
    {
        public BaseHero ProduceHero(string type, string name)
        {
            BaseHero bhero = null;
            if (type == "Druid")
            {
                bhero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                bhero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                bhero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                bhero = new Warrior(name);
            }

            if (bhero == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHeroExcMsg);
            }
            return bhero;
        }
    }
}
