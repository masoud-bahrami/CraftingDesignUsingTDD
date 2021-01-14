using System.Linq;

namespace GoldInvestment.ApplicationService
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command)
            where T : ICommand;
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IResolver _resolver;

        public CommandDispatcher(IResolver resolver)
        {
            this._resolver = resolver;
        }

        public void Dispatch<T>(T command)
            where T : ICommand
        {
            var commandHandler = _resolver.Resolve(typeof(IWantToHandlerCommand<T>));

            var methods = commandHandler.GetType().GetMethods();
            var handleMethod = methods.FirstOrDefault(p => p.Name == "Handle");

            handleMethod.Invoke(commandHandler, new object[] { command });
        }
    }
}