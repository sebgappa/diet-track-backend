using DietTrack.SuperMarket.DataViews;

namespace DietTrack.SuperMarket.Core.Infrastructure
{
    public interface IQuery<TResult>
        where TResult : IDataView
    {
    }
}
