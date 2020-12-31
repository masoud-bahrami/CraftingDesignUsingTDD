using GoldInvestment.ApplicationService;
using GoldInvestment.Infrastructure.UnitTests.Helpers;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class CommandDispatcherTests
    {
        [Fact]
        public void Dispatch_WhenAnCommandDispatch_CommandHandlerInvoked()
        {
            ISimpleContainer simpleContainer = new SimpleContainer();
            var fakeCommandHandler = new FakeCommandHandler();

            simpleContainer.Register(typeof(FakeCommand), () => fakeCommandHandler);

            ICommandDispatcher sut = new CommandDispatcher(simpleContainer);
                        
            ICommand fakeCommand = new FakeCommand();
            sut.Dispatch(fakeCommand);

            fakeCommandHandler.Verify();
        }
    }
}
