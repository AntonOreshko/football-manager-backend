using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders;
using BusinessLayer.ServiceInterfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/fill")]
    [ApiController]
    public class DatabaseFillController : ControllerBase
    {
        private readonly IEntityService<User> _userService;

        public DatabaseFillController(IEntityService<User> userService)
        {
            _userService = userService;
        }

        // GET: api/fill/add
        [HttpGet("add")]
        public IActionResult AddUser()
        {
            var user = UserBuilder.GetRandom();

            _userService.Insert(user);
            _userService.SaveChanges();

            return Ok(UserViewModel.Get(user));
        }

        // GET: api/fill/add/5
        [HttpGet("add/{count}")]
        public IActionResult AddUsers([FromRoute] int count)
        {
            var users = new List<User>();

            for (int i = 0; i < count; i++)
            {            
                var user = UserBuilder.GetRandom();
                users.Add(user);
                _userService.Insert(user);
            }

            _userService.SaveChanges();

            var viewModels = users.Select(UserViewModel.Get).ToList();

            return Ok(viewModels);
        }

    }
}