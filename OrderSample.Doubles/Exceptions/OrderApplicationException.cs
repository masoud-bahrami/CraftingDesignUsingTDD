using System;

namespace TDD.Samples.Doubles.Exceptions
{
    public class OrderApplicationException : Exception
    {
        public OrderApplicationException(string msg)
            :base(msg){
            
        }
    }
}