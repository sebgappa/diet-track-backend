using DietTrack.SuperMarket.Core.Infrastructure;
using DietTrack.SuperMarket.DataViews;

namespace DietTrack.SuperMarket.Core.Domain.Foods.Queries
{
    public class GetFoodQuery: IQuery<Food>
    {
        public long Barcode { get; set; }
        public GetFoodQuery(long barcode)
        {
            Barcode = barcode;
        }
    }
}
