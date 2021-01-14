using GoldInvestment.ApplicationService;
using GoldInvestment.Infrastructure.UnitTests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


namespace GoldInvestment.Infrastructure.UnitTests
{
    public class SimpleContainerTests
    {
        [Fact]
        public void Resolve_SuccessfullyResolveAndRegisteredComponent()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IWantToHandlerCommand<FakeCommand>,FakeCommandHandler>();

            IResolver sut = new Resolver(serviceCollection.BuildServiceProvider());

            var result = sut.Resolve(typeof(IWantToHandlerCommand<FakeCommand>));
            Assert.Equal(typeof(FakeCommandHandler), result.GetType());
        }

        [Fact]
        public void Resolve_ResolveGenericComponent()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IWantToHandlerCommand<FakeCommand>, FakeCommandHandler>();

            IResolver sut = new Resolver(serviceCollection.BuildServiceProvider());
            var result = sut.Resolve<IWantToHandlerCommand<FakeCommand>>();

            Assert.Equal(typeof(FakeCommandHandler), result.GetType());
        }

        [Fact]
        public void Resolve_IfDependencyNotRegistered_ExceptionThrown()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            IResolver sut = new Resolver(serviceCollection.BuildServiceProvider());

            var result = Assert.Throws<NotRegisteredDependencyException>(() => sut.Resolve(typeof(FakeCommand)));

            Assert.Equal($"{nameof(FakeCommand)} not registered!", result.Message);
        }
    }
}