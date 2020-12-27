using System;
using GoldInvestment.ApplicationService;
using GoldInvestment.ApplicationService.Contract;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class CommandDispatcherTests
    {
        [Fact]
        public void Dispatch_WhenAnCommandDispatch_CommandHandlerInvoked()
        {
            ISimpleContainer simpleContainer = new SimpleContainer();
            simpleContainer.Register(typeof(FakeCommand), () => new FakeCommandHandler());

            ICommandDispatcher sut = new CommandDispatcher(simpleContainer);

            var fakeCommandHandler = new FakeCommandHandler();

            ICommand fakeCommand = new FakeCommand();
            sut.Dispatch(fakeCommand);

            fakeCommandHandler.Verify();
        }
    }
}
