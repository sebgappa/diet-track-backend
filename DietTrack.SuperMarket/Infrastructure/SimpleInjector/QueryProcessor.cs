using DietTrack.SuperMarket.Core.Infrastructure;
using DietTrack.SuperMarket.Core.Infrastructure.Queries;
using DietTrack.SuperMarket.DataViews;
using SimpleInjector;
using System;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Infrastructure.SimpleInjector
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly Container _container;

        public QueryProcessor(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public async Task<TResult> Process<TResult>(IQuery<TResult> query) where TResult : IDataView
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var wrapperType = typeof(QueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            var handler = _container.GetInstance(handlerType);
            if (handler == null)
            {
                throw new Exception(query.GetType().ToString());
            }

            QueryHandler<TResult> wrappedHandler = (QueryHandler<TResult>)Activator.CreateInstance(wrapperType, handler);

            var result = await wrappedHandler.HandleAsync(query);
            return result;
        }

        private abstract class QueryHandler<TResult> where TResult : IDataView
        {
            public abstract Task<TResult> HandleAsync(IQuery<TResult> query);
        }

        private class QueryHandler<TQuery, TResult> : QueryHandler<TResult>
            where TQuery : IQuery<TResult> where TResult : IDataView
        {
            private readonly IQueryHandler<TQuery, TResult> _handler;

            public QueryHandler(IQueryHandler<TQuery, TResult> handler)
            {
                _handler = handler;
            }

            public override Task<TResult> HandleAsync(IQuery<TResult> query)
            {
                return _handler.HandleAsync((TQuery)query);
            }
        }
    }
}
