using TDD.Samples.Doubles.Domain;
using TDD.Samples.Doubles.Exceptions;

namespace TDD.Samples.Doubles.EventPublisher
{
    internal class KafkaEventPublisher : IEventPublisher
    {
        public void Publish(OrderCreated orderCreated)
        {
            throw new EventPublisherException("Could not publish event to kafka topic");
        }
    }
}