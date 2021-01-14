using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace GoldInvestment.ApplicationService
{
    public interface IResolver
    {
        object Resolve(Type type);
        T Resolve<T>();
    }

    public class Resolver : IResolver
    {
        private readonly Dictionary<Type, Func<object>> _components = new Dictionary<Type, Func<object>>();

        private readonly ServiceProvider serviceCollection;

        public Resolver()
        {

        }

        public Resolver(ServiceProvider serviceCollection)
        {

            this.serviceCollection = serviceCollection;
        }

        public object Resolve(Type type)
        {
            var service = serviceCollection.GetService(type);
            if (service == null)
                throw new NotRegisteredDependencyException(type);

            return service;
        }

        public T Resolve<T>() => serviceCollection.GetService<T>();
    }
}