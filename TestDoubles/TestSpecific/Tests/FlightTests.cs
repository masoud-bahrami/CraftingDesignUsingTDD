using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestDoubles.TestSpecific.Tests
{
    public class FlightDbContextFactoryTestSpecific : IFlightDbContextFactory
    {
        public FlightDbContext Create()
        {
            return new FlightDbContext();
        }

    }
    /// <summary>
    /// Loopback
    /// Self-Shunt
    /// </summary>
    public class FlightTests : IFlightDbContextFactory
    {
        
        [Fact]
        public void TestAddFlight()
        {
            var flightId = "1";
            var flightNumber = "TM123";

            var flight = new Flight(flightId, flightNumber);

            var sut = new FlightRepository(Create());

            sut.Create(flight);

            flight = sut.Get("1");

            Assert.Equal(flightNumber, flight.FlightNumber);
        }

        [Fact]
        public void TestAddFlight1()
        {
            var flightId = "1";
            var flightNumber = "TM123";

            var flight = new Flight(flightId, flightNumber);

            var sut = new FlightRepository(Create());

            sut.Create(flight);

            flight = sut.Get("1");

            Assert.Equal(flightNumber, flight.FlightNumber);
        }

        public FlightDbContext Create()
        {
            return new FlightDbContext();
        }
    }
}
