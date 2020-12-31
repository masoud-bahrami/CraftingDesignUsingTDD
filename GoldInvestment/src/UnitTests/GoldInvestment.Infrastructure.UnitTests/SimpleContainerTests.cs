using GoldInvestment.ApplicationService;
using GoldInvestment.Infrastructure.UnitTests.Helpers;
using Xunit;


namespace GoldInvestment.Infrastructure.UnitTests
{
    public class SimpleContainerTests
    {
        [Fact]
        public void Resolve_SuccessfullyResolveAndRegisteredComponent()
        {
            ISimpleContainer sut = new SimpleContainer();
            sut.Register(typeof(FakeCommand), () => new FakeCommandHandler());
            var result = sut.Resolve(typeof(FakeCommand));
            Assert.Equal(typeof(FakeCommandHandler), result.GetType());
        }

        [Fact]
        public void Resolve_IfDependencyNotRegistered_ExceptionThrown()
        {
            ISimpleContainer sut = new SimpleContainer();

            var result = Assert.Throws<NotRegisteredDependencyException>(() => sut.Resolve(typeof(FakeCommand)));

            Assert.Equal($"{nameof(FakeCommand)} not registered!" , result.Message);
        }
    }
}