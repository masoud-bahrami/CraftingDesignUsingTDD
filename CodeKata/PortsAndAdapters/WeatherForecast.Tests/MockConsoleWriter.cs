using WeatherForeCast.ConsoleAdapter;
using Xunit;

namespace WeatherForecast.Tests
{
    public class MockConsoleWriter : IConsoleWriter
    {
        private string _expectedMessage;
        private string _actualMessage;


        public void WriteLine(string message)
        {
            _actualMessage = message;
        }

        public void Setup(string expectedMessage)
        {
            _expectedMessage = expectedMessage;
        }

        public void Verify()
        {
            Assert.Equal(_expectedMessage, _actualMessage);
        }
    }
}