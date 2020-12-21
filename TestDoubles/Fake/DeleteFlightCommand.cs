namespace TestDoubles.Fake
{
    public class DeleteFlightCommand : ICommand
    {
        public string FlightId { get;  set; }

        public DeleteFlightCommand(string flightId)
        {
            FlightId = flightId;
        }
    }
}