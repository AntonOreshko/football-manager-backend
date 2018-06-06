using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Models.Context;
using Backend.ViewModels;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly FootballManagerContext _context;

        public ClubsController(FootballManagerContext context)
        {
            _context = context;
        }

        // GET: api/Clubs/5/players
        [HttpGet("{id}/players")]
        public async Task<IActionResult> GetPlayers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var players = await _context.Players
                .Include(p => p.Stats)
                .Where(p => p.ClubId == id)
                .ToListAsync();

            var viewModels = new List<PlayerViewModel>();

            foreach (var p in players)
            {
                viewModels.Add(new PlayerViewModel(p));
            }

            return Ok(viewModels);
        }

        // GET: api/Clubs/5/players/1
        [HttpGet("{id}/players/{position}")]
        public async Task<IActionResult> GetPlayersOnPosition([FromRoute] int id, [FromRoute] PlayerPosition position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var players = await _context.Players
                .Include(p => p.Stats)
                .Where(p => p.ClubId == id && p.FirstPosition == position)
                .ToListAsync();

            var viewModels = new List<PlayerViewModel>();

            foreach (var p in players)
            {
                viewModels.Add(new PlayerViewModel(p));
            }

            return Ok(viewModels);
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}