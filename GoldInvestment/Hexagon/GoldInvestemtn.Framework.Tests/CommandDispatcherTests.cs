using GoldInvestment.ApplicationService;
using GoldInvestment.Infrastructure.UnitTests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class CommandDispatcherTests
    {
        [Fact]
        public void Dispatch_WhenAnCommandDispatch_CommandHandlerInvoked()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped< IWantToHandlerCommand<FakeCommand> , FakeCommandHandler > ();
            IResolver resolver = new Resolver(serviceCollection.BuildServiceProvider());
            
            ICommandDispatcher sut = new CommandDispatcher(resolver);

            var fakeCommand = new FakeCommand();
            sut.Dispatch(fakeCommand);

            var fakeCommandHandler = resolver.Resolve<IWantToHandlerCommand<FakeCommand>>();
            ((FakeCommandHandler)fakeCommandHandler).Verify();
        }
    }
}
