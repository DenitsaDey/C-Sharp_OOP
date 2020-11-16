using Logger.Enums;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }
        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public Level Level { get; private set; }
    }
}
