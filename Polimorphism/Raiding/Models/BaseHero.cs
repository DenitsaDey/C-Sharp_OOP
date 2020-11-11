using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero

    {
        private string name;

        private int power; 

        public BaseHero(string name)
        {
            this.Name = name;
        }
        
        public string Name { get; private set; }

        public int Power { get; protected set; }


        public abstract string CastAbility();
    }
}
