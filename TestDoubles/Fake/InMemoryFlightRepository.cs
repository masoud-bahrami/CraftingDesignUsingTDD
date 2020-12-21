using System.Collections.Generic;
using System.Linq;

namespace TestDoubles.Fake
{
    public class InMemoryFlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flights;

        public InMemoryFlightRepository()
        {
            this._flights = new List<Flight>();
        }

        public void Add(Flight flight)
        {
            _flights.Add(flight);
        }

        public void Delete(string flightId)
        {
            var flight = GetFlight(flightId);
            _flights.Remove(flight);
        }

        public Flight GetFlight(string flightId)
        {
            return _flights.FirstOrDefault(f => f.FlightId == flightId);
        }

        public int Count() => _flights.Count;
    }
}