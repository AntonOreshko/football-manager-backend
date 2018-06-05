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

        // GET: api/addusers/10
        [HttpGet("{count}")]
        public async Task<IActionResult> AddUsers([FromRoute] int count)
        {
            _context.Users.RemoveRange(_context.Users);

            await _context.SaveChangesAsync();

            for (int i = 0; i < count; i++)
            {
                _context.Users.Add(UserBuilder.GetRandomUser());
            }

            _context.SaveChanges();

            return Ok("users added");
        }
    }
}