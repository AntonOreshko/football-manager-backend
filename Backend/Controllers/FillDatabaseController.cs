using System.Threading.Tasks;
using Backend.Builders;
using Backend.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/fill")]
    public class FillDatabaseController : Controller
    {
        private readonly FootballManagerContext _context;

        public FillDatabaseController(FootballManagerContext context)
        {
            _context = context;
        }

        // GET: api/clearcontext
        [HttpGet("clearcontext")]
        public async Task<IActionResult> ClearContext()
        {
            _context.Users.RemoveRange(_context.Users);

            await _context.SaveChangesAsync();

            return Ok("context cleared");
        }

        // GET: api/fill/adduser
        [HttpGet("adduser")]
        public async Task<IActionResult> AddUser()
        {
            var user = UserBuilder.GetRandomUser();

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok("users added");
        }

        // GET: api/fill/addusers/10
        [HttpGet("addusers/{count}")]
        public async Task<IActionResult> AddUsers([FromRoute] int count)
        {
            for (int i = 0; i < count; i++)
            {
                _context.Users.Add(UserBuilder.GetRandomUser());
            }

            await _context.SaveChangesAsync();

            return Ok("users added");
        }
    }
}