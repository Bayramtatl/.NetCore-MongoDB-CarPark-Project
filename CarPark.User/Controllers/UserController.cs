using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        public UserController(IStringLocalizer<UserController> localizer) 
        {
            _localizer= localizer;
        }
        public IActionResult Index()
        {
            var nameSurnameValue = _localizer["NameSurname"];

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {

            return View(request);
        }
    }
}
