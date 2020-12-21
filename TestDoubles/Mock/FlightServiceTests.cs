using System;
using Xunit;

namespace TestDoubles.Mock
{
    public class FlightLoggerMock : ILogger
    {
        private DateTime _actualDate;
        private string _actualFlightId;
        private string _actualMsg;
        private string _actualMethod;

        private string _expectedMethod;
        private string _expectedFlightId;
        private string _expectedMsg;

        public void LogInformation(DateTime dateTime, string id, string msg)
        {
            _actualMethod = nameof(LogInformation);
            _actualDate = dateTime;
            _actualFlightId = id;
            _actualMsg = msg;
        }

        public void LogError(DateTime dateTime, string id, string msg)
        {
            _actualMethod = nameof(LogError);
            _actualDate = dateTime;
            _actualFlightId = id;
            _actualMsg = msg;
        }

        public void Setup(string expectedMethod, string expectedFlightId, string expectedMsg)
        {
            _expectedMethod = expectedMethod;
            _expectedFlightId = expectedFlightId;
            _expectedMsg = expectedMsg;
        }

        public void Verify()
        {
            Assert.Equal(_expectedMethod, _actualMethod);
            Assert.Equal(_expectedFlightId, _actualFlightId);
            Assert.Equal(_expectedMsg, _actualMsg);
        }
    }
    public class FlightServiceTests
    {
        [Fact]
        public void TestLogDeletedFlight()
        {
            var flightLoggerMock = new FlightLoggerMock();
            var flightId = "1";

            flightLoggerMock.Setup(nameof(FlightLoggerMock.LogInformation), flightId, $"flight {flightId} is deleted");

            FlightService flightService = new FlightService(flightLoggerMock);

            flightService.RemoveFlight(flightId);

            flightLoggerMock.Verify();
        }
    }
}