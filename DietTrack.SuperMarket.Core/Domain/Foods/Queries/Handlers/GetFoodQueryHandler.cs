using System.Threading.Tasks;
using DietTrack.SuperMarket.Core.Infrastructure.Queries;
using DietTrack.SuperMarket.DataViews;

namespace DietTrack.SuperMarket.Core.Domain.Foods.Queries.Handlers
{
    public class GetFoodQueryHandler : IQueryHandler<GetFoodQuery, Food>
    {
        public Task<Food> HandleAsync(GetFoodQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
