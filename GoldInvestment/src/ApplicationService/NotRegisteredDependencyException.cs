using System;

namespace GoldInvestment.ApplicationService
{
    public class NotRegisteredDependencyException : Exception
    {
        public NotRegisteredDependencyException(Type type)
            : base($"{type.Name} not registered!")
        {

        }
    }
}