using WeatherForecast.Hexagon.DrivenPorts;
using Xunit;

namespace WeatherForecast.Tests
{
    public class MockSmsSenderPort : ISmsSenderPort
    {
        private string _expectedNumber;
        private string _expectedMessage;
        private string _actualNumber;
        private string _actualMessage;

        public void SendSms(string to, string message)
        {
            _actualNumber = to;
            _actualMessage = message;
        }

        public void Setup(string expectedNumber, string expectedMessage)
        {
            _expectedNumber = expectedNumber;
            _expectedMessage = expectedMessage;
        }

        public void Verify()
        {
            Assert.Equal(_expectedNumber, _actualNumber);
            Assert.Equal(_expectedMessage, _actualMessage);
        }
    }
}