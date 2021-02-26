using System.Collections.Generic;
using System.Threading.Tasks;
using DietTrack.SuperMarket.Core.Infrastructure.Queries;
using DietTrack.SuperMarket.DataViews;

namespace DietTrack.SuperMarket.Core.Domain.Foods.Queries.Handlers
{
    public class GetFoodQueryHandler : IQueryHandler<GetFoodQuery, Food>
    {
        public Task<Food> HandleAsync(GetFoodQuery query)
        {
            var data = new Food
            {
                Protein = 22,
                Fat = 32,
                Carbs = 47
            };

            return Task.FromResult(data);
        }
    }
}
