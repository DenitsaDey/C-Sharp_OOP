using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class IPerson : INameable, IAgeable, IBuyer
    {
        public string Name { get; set; }

        public string Age { get; set; }
        public int Food { get ; set; }

        public abstract void BuyFood();
        
    }
}
