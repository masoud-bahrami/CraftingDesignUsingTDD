using System;
using System.Linq;

namespace GoldInvestment.ApplicationService
{
    public interface IQueryDispatcher
    {
        T1 RunQuery<T, T1>(T query)
            where T : IQuery;
    }

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IResolver _resolver;

        public QueryDispatcher(IResolver resolver)
        {
            this._resolver = resolver;
        }

        public T1 RunQuery<T, T1>(T query)
            where T : IQuery

        {
            object component;

            try
            {
                component = _resolver.Resolve(typeof(IWantToHandleQuery<T, T1>));
            }
            catch (NotRegisteredDependencyException e)
            {
                throw new NotRegisteredQueryHandlerException<T>();
            }

            var methodInfo = component.GetType().GetMethods()
                .FirstOrDefault(m => m.Name == "Run");

            var result = methodInfo.Invoke(component, new object[] { query });

            return (T1)result;
        }
    }
}