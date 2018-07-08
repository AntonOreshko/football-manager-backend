using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Builders;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApi.BuilderData;
using WebApi.Data;
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

        // GET: api/Users/5
        [Authorize]
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

        [HttpPost("/token")]
        public async Task Token(UserLoginData userLoginData)
        {
            var login = userLoginData.Login;
            var password = userLoginData.Password;

            var identity = GetIdentity(login, password);

            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
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

        // GET: api/Users
        [Authorize]
        [HttpGet]
        public IEnumerable<UserViewModel> GetUsers()
        {
            return _userService.GetAll().Select(UserViewModel.Get);
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            var user = _userService.GetAll().First(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
                };

                var claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}