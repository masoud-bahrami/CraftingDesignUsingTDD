namespace XUnitTestProject1
{
    public interface ICommand
    {
        void Execute();
    }

    //Invoker
    public class CommandInvoker
    {
        private readonly ICommand _powerOffCommand;
        private readonly ICommand _powerOnCommand;

        public CommandInvoker(ICommand powerOffCommand, ICommand powerOnCommand)
        {
            _powerOffCommand = powerOffCommand;
            _powerOnCommand = powerOnCommand;
        }

        public void PowerOff()
        {
            //TODO
            _powerOffCommand.Execute();
        }

        public void PowerOn()
        {
            //TODO
            _powerOnCommand.Execute();
        }
    }

    //Command
    public class FanPowerOfCommand : ICommand
    {
        //Receiver
        private readonly ISwitchable _switchable;

        public FanPowerOfCommand(ISwitchable switchable)
        {
            this._switchable = switchable;
        }

        public void Execute()
        {
            //Delegate
            //
            _switchable.PowerOf();
        }
    }

    //Command
    public class FanPowerOnCommand : ICommand
    {
        private readonly ISwitchable _switchable;

        public FanPowerOnCommand(ISwitchable switchable)
        {
            this._switchable = switchable;
        }

        public void Execute()
        {
            _switchable.PowerOn();
        }
    }
    
    public interface ISwitchable
    {
        void PowerOf();
        void PowerOn();
    }


    //Receiver
    public  class Fan : ISwitchable
    {
        public void PowerOf()
        {
            
        }

        public void PowerOn()
        {
        }
    }

    public  class  TV : ISwitchable
    {
        public void PowerOf()
        {
            
        }

        public void PowerOn()
        {
            
        }
    }
}