using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestDoubles.Fake.Tests
{
    public class FlightRepositoryInMemory : IFlightRepository
    {
        private readonly IList<Flight> _flights = new List<Flight>();
        public void Add(Flight flight) => _flights.Add(flight);

        public void Delete(string flightId) => _flights.Remove(GetFlight(flightId));

        public Flight GetFlight(string flightId) => _flights.Single(f => f.FlightId == flightId);

        public int Count() => _flights.Count;
    }
    public class CommandDispatcherFake : ICommandDispatcher
    {
        private readonly Dictionary<Type, object> _commandHandlersDictionary
            = new Dictionary<Type, object>();


        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = _commandHandlersDictionary[typeof(T)];

            ((ICommandHandler<T>)handler).Handle(command);
        }

        public void Setup(Type type, object handler)
        {
            _commandHandlersDictionary.Add(type, handler);
        }
    }
    public class FlightTests
    {
        //Add Flight
        //Get 
        //Delete

        [Fact]
        public void TestDeleteFlight()
        {
            var commandDispatcherFake = new CommandDispatcherFake();
            var flightRepositoryInMemory = new FlightRepositoryInMemory();
            var flightId = "1";

            flightRepositoryInMemory.Add(new Flight { FlightId = flightId });
            commandDispatcherFake.Setup(typeof(DeleteFlightCommand), new DeleteFlightCommandHandler(flightRepositoryInMemory));

            var sut = new FlightServiceFacade(commandDispatcherFake);

            sut.DeleteFlight(flightId);
            
            Assert.Equal(0, flightRepositoryInMemory.Count());
        }
    }
}
