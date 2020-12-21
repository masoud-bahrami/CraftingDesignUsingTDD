using System;

namespace TDD.Samples.Doubles.Exceptions
{
    public class LoggerException : Exception
    {
        public LoggerException(string msg)
            : base(msg)
        {

        }
    }
}