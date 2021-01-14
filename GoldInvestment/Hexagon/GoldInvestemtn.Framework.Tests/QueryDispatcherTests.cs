using GoldInvestment.ApplicationService;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class QueryDispatcherTests
    {
        [Fact]
        public void DispatchTheQuery_HandlerNotRegistered_ExceptionThrown()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            IQuery fakeQuery = new FakeQuery();
            IResolver resolver = new Resolver(serviceCollection.BuildServiceProvider());

            IQueryDispatcher queryDispatcher = new QueryDispatcher(resolver);

            Assert.Throws<NotRegisteredQueryHandlerException<FakeQuery>>(() => queryDispatcher.RunQuery<FakeQuery, FakeQueryResult>(new FakeQuery()));

        }

        [Fact]
        public void DispatchTheQuery_ThereIsAnHandler_QueryHandlerIsInvoked()
        {
            IServiceCollection serviceCollection = new ServiceCollection();


            serviceCollection.AddScoped<IWantToHandleQuery<FakeQuery, FakeQueryResult>, FakeQueryHandler>();

            IResolver resolver = new Resolver(serviceCollection.BuildServiceProvider());

            IQueryDispatcher queryDispatcher = new QueryDispatcher(resolver);

            queryDispatcher.RunQuery<FakeQuery, FakeQueryResult>(new FakeQuery());

            var queryHandler = resolver.Resolve<IWantToHandleQuery<FakeQuery, FakeQueryResult>>();
            ((FakeQueryHandler)queryHandler).Verify();
        }
    }



    public class FakeQueryHandler : IWantToHandleQuery<FakeQuery, FakeQueryResult>
    {
        private bool _isCalled = false;
        public FakeQueryResult Run(FakeQuery query)
        {
            _isCalled = true;
            return default;
        }

        internal void Verify()
        {
            Assert.True(_isCalled);
        }
    }




    public class FakeQuery : IQuery
    {
    }

    public class FakeQueryResult
    {

    }
}