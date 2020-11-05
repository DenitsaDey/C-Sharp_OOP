using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class InvalidURLException : Exception
    {
        private const string ExcMsg = "Invalid URL!";

        public InvalidURLException()
            :base(ExcMsg)
        {

        }

        public InvalidURLException(string message)
            :base(message)
        {

        }
    }
}
