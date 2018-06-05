using System.Linq;
using System.Threading.Tasks;
using Backend.Builders;
using Backend.Builders.Data;
using Microsoft.AspNetCore.Mvc;
using Backend.Models.Context;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FootballManagerContext _context;

        public UsersController(FootballManagerContext context)
        {
            _context = context;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.GetViewModel());
        }

        // POST api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserBuilderData builderData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = UserBuilder.GetUser(builderData);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user.GetViewModel());
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}