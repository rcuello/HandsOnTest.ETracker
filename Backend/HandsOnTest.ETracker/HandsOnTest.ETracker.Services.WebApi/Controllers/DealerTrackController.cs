using HandsOnTest.ETracker.Domain.DealerTrack;
using HandsOnTest.ETracker.Domain.ViewModel;
using HandsOnTest.ETracker.Services.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnTest.ETracker.Services.WebApi.Controllers
{
    /// <summary>
    /// Parse a csv file and returns list of sales
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DealerTrackController : ControllerBase
    {
        private readonly IDealerTrackDomain _dealerTrackDomain;
        public DealerTrackController(IDealerTrackDomain dealerTrackDomain)
        {
            _dealerTrackDomain = dealerTrackDomain;

        }
        /// <summary>
        /// Parse a csv file and returns list of sales
        /// </summary>
        /// <param name="file">A csv file where each row represents a sale of a vehicle</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/DealerTrack/Parse
        ///
        /// </remarks>
        /// <returns>list of sales to retrieve</returns>
        /// <response code="200">If csv file is valid return list of sales
        /// </response>
        [HttpPost("Parse")]
        public async Task<IActionResult> Parse([FromForm] DealerTrackViewModel model)
        {
            var result = await _dealerTrackDomain.ProcessFile(model.File);
            return Ok(result);
        }
    }

}
