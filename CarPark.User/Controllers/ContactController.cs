using Microsoft.AspNetCore.Mvc;

namespace CarPark.User.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
