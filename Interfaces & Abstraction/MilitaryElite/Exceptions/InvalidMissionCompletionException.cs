using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DefExcMsg = "Mission already completed!";


        public InvalidMissionCompletionException()
            : base(DefExcMsg)
        {

        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {

        }
    }
}
