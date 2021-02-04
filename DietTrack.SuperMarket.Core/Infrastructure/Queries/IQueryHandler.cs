using DietTrack.SuperMarket.DataViews;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Core.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : IDataView
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
