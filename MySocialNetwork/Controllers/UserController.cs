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
        IWebHostEnvironment _appEnvironment;


        public UserController(IUserRepository userRepository, IWebHostEnvironment appEnvironment)
        {
            _userRepository = userRepository;
            _appEnvironment = appEnvironment;
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
            UserDal userDal = _userRepository.GetUserById(id);
            if (userDal == null) return BadRequest("user not found");
            if (userDal.Avatar == null) userDal.Avatar = "default.jpg";
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
            string path = "";
            IFormFile image = dto.Avatar;
            SaveImage(image);
            var id = _userRepository.CreateUser(new UserDal
            {
                Login = dto.Login,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                City = dto.City,
                Address = dto.Address,
                Avatar = image.FileName
            }) ;
            return Ok(id);
        }

        private async void SaveImage(IFormFile image)
        {
            if (image != null)
            {
                // путь к папке Files
                string path = image.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/Files/" + path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
        }
    }
}
