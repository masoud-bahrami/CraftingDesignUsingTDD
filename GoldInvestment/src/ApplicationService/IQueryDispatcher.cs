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
        private readonly ISimpleContainer _simpleContainer;

        public QueryDispatcher(ISimpleContainer simpleContainer)
        {
            this._simpleContainer = simpleContainer;
        }

        public T1 RunQuery<T, T1>(T query)
            where T : IQuery
        
        {
            var component = _simpleContainer.Resolve(typeof(IWantToHandleQuery<T, T1>));

            var methodInfo = component.GetType().GetMethods()
                .FirstOrDefault(m => m.Name == "Run");

            var result = methodInfo.Invoke(component, new object[] { query });

            return (T1)result;
        }
    }
}