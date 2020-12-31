using System.Threading.Tasks;
using GoldInvestment.ApplicationService;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests.Helpers
{
    public class FakeCommandHandler : IWantToHandlerCommand<FakeCommand>
    {
        private bool _isCalled;

        public void Verify() => Assert.True(_isCalled, $"Expected: {nameof(FakeCommandHandler)} should be called. But it was not called!");

        public Task Handle(FakeCommand command)
        {
            _isCalled = true;

            return Task.CompletedTask;
        }
    }
}