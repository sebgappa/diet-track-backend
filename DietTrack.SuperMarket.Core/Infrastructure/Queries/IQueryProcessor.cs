using DietTrack.SuperMarket.DataViews;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Core.Infrastructure
{
    public interface IQueryProcessor {

        Task<TResult> Process<TResult>(IQuery<TResult> query) 
            where TResult : IDataView;
    }
}
