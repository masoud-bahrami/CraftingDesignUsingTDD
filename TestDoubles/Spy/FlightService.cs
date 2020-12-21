namespace TestDoubles.Spy
{
    internal class FlightService 
    {
        private readonly ILogger _logger;
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository, ILogger logger)
        {
            this._flightRepository = flightRepository;
            _logger = logger;

            //             Control Freak
            //            _logger = new FileLogger();
        }

        public void RemoveFlight(string flightId)
        {
            //indirect-input
            var flight = _flightRepository.Get(flightId);
            if (flight == null)
            {
                _logger.LogError(System.DateTime.Now, flightId, $"Flight {flightId} not exist!");
                return;
            }

            _flightRepository.Remove(flight);
            //indirect output
            //Interaction
            _logger.LogInformation(System.DateTime.Now, flight.Id, $"Flight {flightId} is deleted!");
        }

    }

    internal interface IFlightRepository
    {
        void Remove(Flight flight);
        Flight Get( string flightId);
    }

    public class Flight
    {
        public string Id { get; set; }
    }
}