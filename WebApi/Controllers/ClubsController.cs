using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders;
using BusinessLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.BuilderData;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        // GET: api/Clubs
        [HttpGet]
        public IEnumerable<ClubViewModel> GetClubs()
        {
            return _clubService.GetAll().Select(ClubViewModel.Get);
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public IActionResult GetClub([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = _clubService.GetWithRelations(id);

            if (club == null)
            {
                return NotFound();
            }

            return Ok(ClubViewModel.Get(club));
        }

        // POST: api/Clubs
        [HttpPost]
        public IActionResult PostClub([FromBody] ClubBuilderData clubBuilderData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var club = ClubBuilder.Get(clubBuilderData);

            _clubService.Insert(club);
            _clubService.SaveChanges();

            return Ok(ClubViewModel.Get(club));
        }
    }
}