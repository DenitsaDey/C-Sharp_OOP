using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        public StationaryPhone()
        {

        }

        public string Call(string number)
        {
            if (!number.All(ch=>char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }
            return $"Dialing... {number}";
        }
    }
}
