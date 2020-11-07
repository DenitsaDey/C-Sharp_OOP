using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IPerson
    {
        private string id;

        private string birthdate;

        public Citizen(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        
        public string Id { get; private set; }

        public string Birthdate { get; private set; }
        

        public override void BuyFood()
        {
            this.Food += 10; ;
        }
    
    }
}
