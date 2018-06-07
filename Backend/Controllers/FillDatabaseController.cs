using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Builders;
using Backend.Models.Context;
using Backend.Models.UserModels;
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

            ClubBuilder.FillSquad(user.Club.Squads.First(), user.Club.Players);

            await _context.SaveChangesAsync();

            return Ok("users added");
        }

        // GET: api/fill/addusers/10
        [HttpGet("addusers/{count}")]
        public async Task<IActionResult> AddUsers([FromRoute] int count)
        {
            var users = new List<User>();

            for (int i = 0; i < count; i++)
            {
                users.Add(UserBuilder.GetRandomUser());
            }

            _context.Users.AddRange(users);

            await _context.SaveChangesAsync();

            foreach (var user in users)
            {
                ClubBuilder.FillSquad(user.Club.Squads.First(), user.Club.Players);
            }

            await _context.SaveChangesAsync();

            return Ok("users added");
        }
    }
}