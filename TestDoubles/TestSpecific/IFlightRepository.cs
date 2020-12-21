namespace TestDoubles.TestSpecific
{
    public interface IFlightRepository
    {
        void Create(Flight flight);
        void Update(Flight flight);
        void Delete(Flight flight);
        int Count();
    }

    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext _flightDbContext;

        public FlightRepository(FlightDbContext flightDbContext)
        {
            _flightDbContext = flightDbContext;
        }

        public void Create(Flight flight)
        {
            _flightDbContext.Add(flight);
        }

        public void Update(Flight flight)
        {
            var originalFlight = _flightDbContext.Get(flight.Id);
            originalFlight.ChangeFlightNumber(originalFlight.FlightNumber);

            _flightDbContext.Update(originalFlight);
        }

        public void Delete(Flight flight)
        {
            _flightDbContext.Delete(flight.Id);
        }

        public int Count()
        {
            return _flightDbContext.Count();
        }

        public Flight Get(string id)
        {
            return _flightDbContext.Get(id);
        }
    }

    internal class FlightDbContextFactory
    {
        private  static FlightDbContext _soleInstance;
        public static FlightDbContext Create()
        {
            if(_soleInstance  == null)
                _soleInstance = new FlightDbContext();

            return _soleInstance ;
        }
    }

    public interface IFlightDbContextFactory
    {
        FlightDbContext Create();
    }
}