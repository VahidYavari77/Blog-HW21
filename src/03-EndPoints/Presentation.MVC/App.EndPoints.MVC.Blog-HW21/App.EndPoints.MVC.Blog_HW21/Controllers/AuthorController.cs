using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using App.EndPoints.MVC.Blog_HW21.Models.AuthorAgg;
using App.EndPoints.MVC.Blog_HW21.Models.LocalStorage;
using Blog_HW21._Framework;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Blog_HW21.Controllers
{
    public class AuthorController (IAuthorAppService authorAppService ) : Controller
    {
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loginDto = new LoginDto
            {
                UserName = model.UserName,
                Password = model.Password.ToMd5Hex()
            };
            var result = authorAppService.Login(loginDto);
            if (result.IsSuccess==true)
            {
                InMemoryDb.CurrentAuthor = result.Data;
                InMemoryDb.CurrentAuthorId = result.Data.Id;
                
                return RedirectToAction("AuthorPanel", "AuthorPanel");
            }
            else
            {
                ViewBag.Massage = "اطلاعات وارد شده صحیح نیست";
                return View("Login");
            }

            
        }
      
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(AuthorVeiwModel model)
        {
            var authordto = new AuthorDto
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                Password=model.Password,
                Email=model.Email,
                UserName=model.FirstName+"-"+model.LastName
            };
            authorAppService.AddAuthor(authordto);

            return RedirectToAction("Login");
        }
    }
}
