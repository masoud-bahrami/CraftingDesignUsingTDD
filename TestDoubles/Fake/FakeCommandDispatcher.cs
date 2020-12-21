using System;
using System.Collections.Generic;

namespace TestDoubles.Fake
{
    public class FakeCommandDispatcher : ICommandDispatcher
    {
        public Dictionary<Type, object> CommandHandlers = new Dictionary<Type, object>();

        public void Register<T>(dynamic commandHandler)
            where T : ICommand
        {
            CommandHandlers.Add(typeof(T), commandHandler);
        }

        public void Dispatch<T>(T command)
            where T : ICommand
        {
            var commandHandler = CommandHandlers[command.GetType()];

            ((ICommandHandler<T>)commandHandler).Handle(command);
        }
    }
}