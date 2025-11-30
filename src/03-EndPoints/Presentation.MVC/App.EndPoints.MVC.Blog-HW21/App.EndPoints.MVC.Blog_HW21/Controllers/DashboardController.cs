using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Blog_HW21.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
