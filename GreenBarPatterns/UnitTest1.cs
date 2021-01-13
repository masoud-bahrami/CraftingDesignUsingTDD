using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {


            //ISwitchable switchable = new Fan();
            //switchable.PowerOf();
            //var command = new FanPowerOfCommand(switchable);

            ISwitchable switchable = new Fan();
            CommandInvoker commandInvoker = new CommandInvoker(
                new FanPowerOnCommand(switchable),
                new FanPowerOfCommand(switchable)
            );

            commandInvoker.PowerOn();
            commandInvoker.PowerOff();
        }
    }
}
