using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Blog_HW21.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
