namespace TestDoubles.Spy
{
    public class FlightRepositoryStub : IFlightRepository
    {
        private readonly Flight _flight;

        public FlightRepositoryStub(Flight flight)
        {
            _flight = flight;
        }

        public void Remove(Flight flight)
        {
            
        }

        public Flight Get(string flightId)
        {
            return _flight;
        }
    }
}