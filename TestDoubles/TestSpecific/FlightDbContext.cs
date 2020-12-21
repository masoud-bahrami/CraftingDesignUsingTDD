using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestDoubles.TestSpecific
{
    public class FlightDbContext 
    {
        private readonly IList<Flight> _flights;

        public FlightDbContext()
        {
            _flights = new List<Flight>();
        }

        public void Add(Flight flight)
        {
            if(_flights.Any(f=>f.Id == flight.Id))
                throw new Exception("Flight id is duplicated!");

            _flights.Add(flight);
        }

        public void Update(Flight flight)
        {

        }

        public Flight Get(string id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }

        public void Delete(string flightId)
        {
            _flights.Remove((Get(flightId)));
        }

        public int Count()
        {
            return _flights.Count;
        }
    }
}