using Xunit;

namespace TestDoubles.Spy
{
    public class FlightServiceTests
    {
        [Fact]
        public void TestFlightNotFoundLogError()
        {
            //Fixture
            LoggerSpy loggerDouble = new LoggerSpy();
            IFlightRepository flightRepositoryStub = new FlightRepositoryStub(null);
            var sut = new FlightService(flightRepositoryStub, loggerDouble);
            var flightId = "1";

            //Exercise
            sut.RemoveFlight(flightId);

            //Assert
            Assert.Equal(nameof(ILogger.LogError), loggerDouble.ActualMethod);
            Assert.Equal(flightId, loggerDouble.ActualId);
            Assert.Equal($"Flight {flightId} not exist!", loggerDouble.ActualMessage);
        }

        [Fact]
        public void TestFlightSuccessfullyRemovedLogInformation()
        {
            //Fixture
            var flightId = "1";
            LoggerSpy loggerDouble = new LoggerSpy();
            IFlightRepository flightRepositoryStub = new FlightRepositoryStub(new Flight { Id = flightId });
            var sut = new FlightService(flightRepositoryStub, loggerDouble);

            //Exercise
            sut.RemoveFlight(flightId);

            //Assert
            Assert.Equal(nameof(ILogger.LogInformation), loggerDouble.ActualMethod);
            Assert.Equal(flightId, loggerDouble.ActualId);
            Assert.Equal($"Flight {flightId} is deleted!", loggerDouble.ActualMessage);
        }
    }
}
