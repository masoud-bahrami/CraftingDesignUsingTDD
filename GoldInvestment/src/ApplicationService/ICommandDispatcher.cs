using System.Linq;

namespace GoldInvestment.ApplicationService
{
    public interface ICommandDispatcher
    {
        void Dispatch(ICommand command);
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ISimpleContainer simpleContainer;

        public CommandDispatcher(ISimpleContainer simpleContainer)
        {
            this.simpleContainer = simpleContainer;
        }

        public void Dispatch(ICommand command)
        {
            var commandHandler =  simpleContainer.Resolve(command.GetType());

            var methods = commandHandler.GetType().GetMethods();
            var handleMethod = methods.FirstOrDefault(p => p.Name == "Handle");

            handleMethod.Invoke(commandHandler, new object[] {command});
        }
    }
}