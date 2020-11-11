using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class UneatableFoodExc : Exception
    {
        
        public UneatableFoodExc(string message)
            : base (message)
        {

        }
    }
}
