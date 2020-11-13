using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    public class InvalidPersonNameException : Exception
    {
        private const string InvalidPersonExcMsg = "Name should contain only letters.";

        public InvalidPersonNameException()
            : base(InvalidPersonExcMsg)
        {

        }

        public InvalidPersonNameException(string message)
            :base (message)
        {

        }
    }
}
