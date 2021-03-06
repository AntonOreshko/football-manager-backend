﻿using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Builders;
using BusinessLayer.ServiceInterfaces;
using DomainModels.Models;
using DomainModels.Models.UserEntities;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/fill")]
    [ApiController]
    public class DatabaseFillController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITournamentService _tournamentService;

        public DatabaseFillController(IUserService userService, ITournamentService tournamentService)
        {
            _userService = userService;
            _tournamentService = tournamentService;
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

        // GET: api/fill/clear
        [HttpGet("clear")]
        public IActionResult ClearContext()
        {
            _userService.Clear();
            _userService.SaveChanges();

            _tournamentService.Clear();
            _tournamentService.SaveChanges();

            return Ok();
        }


    }
}