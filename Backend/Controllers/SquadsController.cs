using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Context;
using Backend.Models.SquadModels;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Squads")]
    public class SquadsController : Controller
    {
        private readonly FootballManagerContext _context;

        public SquadsController(FootballManagerContext context)
        {
            _context = context;
        }

        // GET: api/Squads
        [HttpGet]
        public IEnumerable<Squad> GetSquads()
        {
            return _context.Squads;
        }

        // GET: api/Squads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSquad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var squad = await _context.Squads.SingleOrDefaultAsync(m => m.Id == id);

            if (squad == null)
            {
                return NotFound();
            }

            return Ok(squad);
        }

        // PUT: api/Squads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquad([FromRoute] int id, [FromBody] Squad squad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != squad.Id)
            {
                return BadRequest();
            }

            _context.Entry(squad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SquadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Squads
        [HttpPost]
        public async Task<IActionResult> PostSquad([FromBody] Squad squad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Squads.Add(squad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSquad", new { id = squad.Id }, squad);
        }

        // DELETE: api/Squads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var squad = await _context.Squads.SingleOrDefaultAsync(m => m.Id == id);
            if (squad == null)
            {
                return NotFound();
            }

            _context.Squads.Remove(squad);
            await _context.SaveChangesAsync();

            return Ok(squad);
        }

        private bool SquadExists(int id)
        {
            return _context.Squads.Any(e => e.Id == id);
        }
    }
}