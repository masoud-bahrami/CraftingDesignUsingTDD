using System.Threading.Tasks;
using GoldInvestment.ApplicationService;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class FakeCommandHandler : IWantToHandlerCommand<FakeCommand>
    {
        private bool _isCalled;

        public void Verify()
        {
            Assert.True(_isCalled, "FakeCommandHandler");
        }

        public Task Handle(FakeCommand command)
        {
            _isCalled = true;

            return Task.CompletedTask;
        }
    }
}