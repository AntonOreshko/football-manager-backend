using Backend.Builders;
using Backend.Models.Context;
using Backend.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // GET: api/Users
        [HttpGet]
        public string Fill()
        {
            List<User> users = new List<User>();

            foreach(var user in _context.Users)
            {
                users.Add(user);
            }

            foreach(var user in users)
            {
                _context.Users.Remove(user);
            }

            _context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                _context.Users.Add(UserBuilder.GetUser());
            }

            _context.SaveChanges();

            return "TRUE";
        }

    }
}