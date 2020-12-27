using System;
using System.Collections.Generic;

namespace GoldInvestment.ApplicationService
{
    public interface ISimpleContainer
    {
        object Resolve(Type type);
        void Register(Type type, Func<object> factoryFunc);
    }

    public class SimpleContainer : ISimpleContainer
    {
        private readonly Dictionary<Type , Func<object>> _components = new Dictionary<Type, Func<object>>();
        public void Register(Type type, Func<object> factoryFunc)
        {
            _components[type] = factoryFunc;
        }
        public object Resolve(Type type)
        {
            return _components[type]();
        }

        
    }
}