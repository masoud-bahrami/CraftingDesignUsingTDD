using System.Threading.Tasks;

namespace GoldInvestment.ApplicationService
{
    public interface IWantToHandlerCommand<in T>
        where T : ICommand
    {
        Task Handle(T command);
    }
}