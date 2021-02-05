using System.Collections.Generic;
using System.Threading.Tasks;
using DietTrack.SuperMarket.Core.Infrastructure.Queries;
using DietTrack.SuperMarket.DataViews;

namespace DietTrack.SuperMarket.Core.Domain.Foods.Queries.Handlers
{
    public class GetFoodQueryHandler : IQueryHandler<GetFoodQuery, Paged<Food>>
    {
        public Task<Paged<Food>> HandleAsync(GetFoodQuery query)
        {
            var pagedData = new Paged<Food>
            {
                Total = 10,
                Data = new List<Food>{
                    new Food
                    {
                        Protein = 10,
                        Fat = 10,
                        Carbs = 10
                    }
                },
                Page = query.Page,
                PageSize = query.PageSize
            };

            return Task.FromResult(pagedData);
        }
    }
}
