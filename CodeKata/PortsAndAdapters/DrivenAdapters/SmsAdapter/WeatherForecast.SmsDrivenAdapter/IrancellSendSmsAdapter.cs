using System;
using WeatherForecast.Hexagon.DrivenPorts;

namespace WeatherForecast.SmsDrivenAdapter
{
    public class IrancellSendSmsAdapter : ISmsSenderPort
    {
        public void SendSms(string to, string message)
        {
            throw new NotImplementedException();
        }
    }
}
