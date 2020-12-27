using GoldInvestment.ApplicationService;
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
    }
}