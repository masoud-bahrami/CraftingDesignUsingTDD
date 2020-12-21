using System;

namespace TDD.Samples.Doubles.Exceptions
{
    internal class EventPublisherException : Exception
    {
        public EventPublisherException(string msg):base(msg)
        {
            
        }
    }
}