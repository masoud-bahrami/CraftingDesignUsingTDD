using TDD.Samples.Doubles.Domain;

namespace TDD.Samples.Doubles.EventPublisher
{
    public interface IEventPublisher
    {
        void Publish(OrderCreated orderCreated);
    }
}