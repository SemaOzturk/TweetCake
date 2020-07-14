using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TweetCake.Application.Services;
using TweetCake.DAL;
using TweetCake.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetCake.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("GetUserData")]
        [Authorize(Policy = Policies.User)]
        public IActionResult GetUserData()
        {
            
            return Ok("This is a response from user method");
        }

        [HttpGet]
        [Route("GetAdminData”")]
        [Authorize(Policy = Policies.Admin)]

        public IActionResult GetAdminData()
        {
            return Ok("This is a response from admin method");
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
          return Ok(_userService.GetAllUser());
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateModel userCreate)
        {
            var user = _mapper.Map<User>(userCreate);
            return Ok(_userService.Create(user));
        }

    }
}
