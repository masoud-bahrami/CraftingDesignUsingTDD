namespace TestDoubles.Fake
{
    public interface IFlightRepository
    {
        public void Add(Flight flight);
        void Delete(string flightId);
        Flight GetFlight(string flightId);
        int Count();
    }
}