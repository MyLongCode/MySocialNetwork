using Dal.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CreateNewUser()
        {

        }
    }
}
