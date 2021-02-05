using DietTrack.SuperMarket.Core.Domain.Foods.Commands.Handlers;
using DietTrack.SuperMarket.Core.Domain.Foods.Queries.Handlers;
using DietTrack.SuperMarket.Core.Infrastructure;
using DietTrack.SuperMarket.Core.Infrastructure.Commands;
using DietTrack.SuperMarket.Core.Infrastructure.Queries;
using SimpleInjector;

namespace DietTrack.SuperMarket.Infrastructure.SimpleInjector
{
    internal sealed class ContainerBuilder
    {
        private readonly Container _container;

        public void Build()
        {
            //Commands
            _container.Register<ICommandDispatcher, CommandDispatcher>(Lifestyle.Scoped);
            _container.Register(typeof(ICommandHandler<>), typeof(SaveFoodCommandHandler).Assembly, Lifestyle.Scoped);

            //Queries
            _container.Register<IQueryProcessor, QueryProcessor>(Lifestyle.Scoped);
            _container.Register(typeof(IQueryHandler<,>), typeof(GetFoodQueryHandler).Assembly, Lifestyle.Scoped);

            _container.Verify();
        }

        public ContainerBuilder(Container container)
        {
            _container = container;
        }
    }
}
