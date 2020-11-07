using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IPerson
    {

        private string group;

        public Rebel(string name, string age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }


        public string Group { get; private set; }


        public override void BuyFood()
        {
            this.Food += 5; ;
        }
    }
}
