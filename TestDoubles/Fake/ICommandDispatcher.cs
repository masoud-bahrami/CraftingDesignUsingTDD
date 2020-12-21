namespace TestDoubles.Fake
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
    }

    public  class CommandDispatcher : ICommandDispatcher
    {
        public void Dispatch<T>(T command) where T : ICommand
        {
            //TODO
        }
    }
}