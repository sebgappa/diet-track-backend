using DietTrack.SuperMarket.Core.Infrastructure;
using DietTrack.SuperMarket.Core.Infrastructure.Commands;
using SimpleInjector;
using System;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Infrastructure.SimpleInjector
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;

        public CommandDispatcher(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public async Task Dispatch(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var wrapperType = typeof(CommandHandler<>).MakeGenericType(command.GetType());

            var handler = _container.GetInstance(handlerType);
            if (handler == null)
            {
                throw new Exception(command.GetType().ToString());
            }

            CommandHandler wrappedHandler = (CommandHandler)Activator.CreateInstance(wrapperType, handler);

            await wrappedHandler.Handle(command);
        }


        private abstract class CommandHandler
        {
            public abstract Task Handle(ICommand command);
        }


        private class CommandHandler<TCommand> : CommandHandler
            where TCommand : ICommand
        {
            private readonly ICommandHandler<TCommand> _handler;

            public CommandHandler(ICommandHandler<TCommand> handler)
            {
                _handler = handler;
            }

            public override Task Handle(ICommand command)
            {
                return _handler.HandleAsync((TCommand)command);
            }
        }
    }
}
