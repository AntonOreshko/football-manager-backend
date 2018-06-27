using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.ServiceInterfaces;
using WebApi.BuilderData;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserViewModel> GetUsers()
        {
            return _userService.GetAll().Select(UserViewModel.Get);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(UserViewModel.Get(user));
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUser([FromBody] UserBuilderData userBuilderData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = UserBuilder.Get(userBuilderData);

            _userService.Insert(user);
            _userService.SaveChanges();

            return Ok(UserViewModel.Get(user));
        }
    }
}