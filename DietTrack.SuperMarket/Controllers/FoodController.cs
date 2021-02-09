using DietTrack.SuperMarket.Core.Domain.Foods.Queries;
using DietTrack.SuperMarket.Core.Infrastructure;
using DietTrack.SuperMarket.DataViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DietTrack.SuperMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryProcessor _queryProcessor;

        public FoodController(ICommandDispatcher commandDispatcher, IQueryProcessor queryProcessor)
        {
            _commandDispatcher = commandDispatcher ?? throw new System.ArgumentNullException(nameof(commandDispatcher));
            _queryProcessor = queryProcessor ?? throw new System.ArgumentNullException(nameof(queryProcessor));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFood([FromQuery] int barcode = 0, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            GetFoodQuery getFood = new GetFoodQuery(barcode, page, pageSize);
            Paged<Food> result = await _queryProcessor.Process(getFood);

            return Ok(result);
        }
    }
}
