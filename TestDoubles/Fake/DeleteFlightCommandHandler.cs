namespace TestDoubles.Fake
{
    public class DeleteFlightCommandHandler : ICommandHandler<DeleteFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightCommandHandler(IFlightRepository flightRepository) => _flightRepository = flightRepository;

        public void Handle(DeleteFlightCommand command)
        {
            _flightRepository.Delete(command.FlightId);
        }
    }
}
