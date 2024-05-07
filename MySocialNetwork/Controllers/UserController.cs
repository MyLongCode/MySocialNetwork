using Dal.User.Interfaces;
using Dal.User.Models;
using Microsoft.AspNetCore.Mvc;
using MySocialNetworkApi.Models.User;
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

        [HttpGet]
        [Route("/user")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers().Select(u => new User { 
                FirstName = u.FirstName,
                LastName = u.LastName,
                City = u.City,
                Address = u.Address,
                Avatar = u.Avatar,
            });
            return View("Users", users);
        }

        [HttpGet]
        [Route("/user/{id}")]
        public IActionResult GetUserInfo(int id)
        {
            var userDal = _userRepository.GetUserById(id);
            return View("UserProfile", new User {
                FirstName = userDal.FirstName,
                LastName = userDal.LastName,
                City = userDal.City,
                Address = userDal.Address,
                Avatar = userDal.Avatar,
            });
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult CreateNewUser(CreateUserRequest dto)
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
