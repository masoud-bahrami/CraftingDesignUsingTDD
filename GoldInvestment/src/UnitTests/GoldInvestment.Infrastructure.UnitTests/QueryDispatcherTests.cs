using GoldInvestment.ApplicationService;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class QueryDispatcherTests
    {
        [Fact]
        public void DispatchTheQuery_HandlerNotRegistered_ExceptionThrown()
        {
            IQuery fakeQuery = new FakeQuery();
            ISimpleContainer simpleContainer = new SimpleContainer();

            IQueryDispatcher queryDispatcher = new QueryDispatcher(simpleContainer);

            Assert.Throws<NotRegisteredQueryHandlerException>(() => queryDispatcher.RunQuery<FakeQuery, FakeQueryResult>(new FakeQuery()));

        }

        [Fact]
        public void DispatchTheQuery_ThereIsAnHandler_QueryHandlerIsInvoked()
        {
            IQuery fakeQuery = new FakeQuery();
            var queryHandler = new FakeQueryHandler();
            
            ISimpleContainer simpleContainer = new SimpleContainer();
            simpleContainer.Register(typeof(IWantToHandleQuery<FakeQuery, FakeQueryResult>), () => queryHandler);

            IQueryDispatcher queryDispatcher = new QueryDispatcher(simpleContainer);

            queryDispatcher.RunQuery<FakeQuery, FakeQueryResult>(new FakeQuery());

            queryHandler.Verify();
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