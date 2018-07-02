using BusinessLayer.Builders;
using BusinessLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public IActionResult GetMatch([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = _matchService.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(MatchViewModel.Get(match));
        }

        // GET: api/Matches/setStartTime
        [HttpGet("setStartTime")]
        public IActionResult SetStartTime()
        {
            var matches = MatchBuilder.SetStartTimeForAllMatches(_matchService);
            _matchService.UpdateRange(matches);
            _matchService.SaveChanges();

            return Ok();
        }
    }
}