using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : INameable, IBithdateable 
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        
        public string Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
