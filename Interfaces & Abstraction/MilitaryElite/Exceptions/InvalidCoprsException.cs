using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidCoprsException : Exception
    {
        private const string DefExcMsg = "Invalid corps!";

        public InvalidCoprsException()
            : base (DefExcMsg)
        {

        }

        public InvalidCoprsException(string message)
            : base(message)
        {

        }
    }
}
