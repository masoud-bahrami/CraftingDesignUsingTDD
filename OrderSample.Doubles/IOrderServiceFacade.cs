using System.Threading.Tasks;

namespace TDD.Samples.Doubles
{
    public interface IOrderServiceFacade
    {
        Task CreateOrder(string customerId);
    }
}