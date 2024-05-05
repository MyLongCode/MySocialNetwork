﻿using Dal.User.Interfaces;
using Dal.User.Models;
using Microsoft.AspNetCore.Mvc;
using MySocialNetworkApi.Models.User.Requests;

namespace MySocialNetworkApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult CreateNewUser([FromBody] CreateUserRequest dto)
        {
            var id = _userRepository.CreateUser(new UserDal
            {
                Login = dto.Login,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                City = dto.City,
                Address = dto.Address,
            });
            return Ok(id);
        }
    }
}