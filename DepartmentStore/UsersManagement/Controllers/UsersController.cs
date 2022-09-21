﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Models.dto;
using UsersManagement.Services;

namespace UsersManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;

        public UsersController (ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet ("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (User))]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate (string login, string password)
        {
            var result = _usersService.Authenticate (login, password);
            return Ok (result);
        }

        [HttpGet]
        public IEnumerable<User> GetAllUser ()
        {
            var result = _usersService.GetAll ();
            return result;
        }
    }
}
