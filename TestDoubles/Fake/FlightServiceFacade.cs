namespace TestDoubles.Fake
{
    public class FlightServiceFacade
    {
        public ICommandDispatcher CommandDispatcher;

        public FlightServiceFacade(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        public void DeleteFlight(string flightId)
        {
            CommandDispatcher.Dispatch(new DeleteFlightCommand(flightId));
        }
    }
}
