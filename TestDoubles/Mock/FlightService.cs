namespace TestDoubles.Mock
{
    public class FlightService
    {
        private readonly ILogger _logger;

        public FlightService(ILogger logger)
        {
            _logger = logger;
        }

        public void RemoveFlight(string flightId)
        {
            //Do something

            _logger.LogInformation(System.DateTime.Now, flightId, $"flight {flightId} is deleted");
        }
    }
}