using System.Collections.Generic;
using System.Linq;

namespace DietTrack.SuperMarket.DataViews
{
    public class Paged<TDataView> : IDataView
        where TDataView : IDataView
    {
        public long Total { get; set; }
        public long Current => Data?.Count() ?? 0;
        public long Page { get; set; }
        public long PageSize { get; set; }
        public IEnumerable<TDataView> Data { get; set; }
    }
}
