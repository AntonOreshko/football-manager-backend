using BusinessLayer.Builders;
using BusinessLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        private readonly IClubService _clubService;

        public TournamentsController(ITournamentService tournamentService, IClubService clubService)
        {
            _tournamentService = tournamentService;
            _clubService = clubService;
        }

        // GET: api/Tournaments/generate/leagues/5
        [HttpGet("generate/leagues/{level}")]
        public IActionResult GenerateLeagues([FromRoute] int level)
        {
            var tournaments = TournamentsBuilder.GetLeagues(level, _clubService);

            _tournamentService.InsertRange(tournaments);
            _tournamentService.SaveChanges();

            return Ok();
        }


        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public IActionResult GetTournament([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tournament = _tournamentService.GetWithRelations(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(TournamentViewModel.Get(tournament));
        }
    }
}