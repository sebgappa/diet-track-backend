using DietTrack.SuperMarket.Core.Infrastructure;
using DietTrack.SuperMarket.DataViews;

namespace DietTrack.SuperMarket.Core.Domain.Foods.Queries
{
    public class GetFoodQuery: IQuery<Paged<Food>>
    {
        public int Barcode { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public GetFoodQuery(int barcode, int page, int pageSize)
        {
            Barcode = barcode;
            Page = page;
            PageSize = pageSize;
        }
    }
}
