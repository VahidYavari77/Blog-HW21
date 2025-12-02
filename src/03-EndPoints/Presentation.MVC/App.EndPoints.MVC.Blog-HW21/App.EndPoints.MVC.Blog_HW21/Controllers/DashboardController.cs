using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.EndPoints.MVC.Blog_HW21.Models.Category;
using App.EndPoints.MVC.Blog_HW21.Models.Dashboard;
using App.EndPoints.MVC.Blog_HW21.Models.LocalStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace App.EndPoints.MVC.Blog_HW21.Controllers
{
    public class DashboardController (ICategoryAppService categoryAppService): Controller
    {
        
        public IActionResult Dashboard()
        {
            int comment=0;
            if (InMemoryDb.CurrentAuthor.Posts != null)
            {
                foreach (var item in InMemoryDb.CurrentAuthor.Posts)
                {
                    comment = item.Comments.Count;
                }
            }
            else
            {
                comment = 0;
            }

            ViewBag.Catrgories = InMemoryDb.CurrentAuthor.Categories;
            ViewBag.Heder = new HederDashboardViewModel
            {
                FullName = InMemoryDb.CurrentAuthor.FirstName + " " + InMemoryDb.CurrentAuthor.LastName,
                CountCategory = InMemoryDb.CurrentAuthor.Categories.Count,
                CountComment=comment,
                CountPost = InMemoryDb.CurrentAuthor.Posts.Count
            };
            return View();
        }

        public IActionResult Logout()
        {
            InMemoryDb.CurrentAuthorId = default;
            InMemoryDb.CurrentAuthor = default;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult CreateCategories(CategoryViewModel model)
        {

            if (model.Title is not null && model.Description is not null)
            {
                var categorydto = new CategoryDto
                {
                    
                    AuthorId = InMemoryDb.CurrentAuthorId,
                    Name = model.Title,
                    Description=model.Description

                };
                var result = categoryAppService.AddCategory(categorydto);
                if (result.Data||result.IsSuccess==false)
                {
                    ViewBag.Massage = result.Message;
                    return View("Dashboard");
                }
                else
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("Dashboard");
                }
            }
            if (model.Title is  null || model.Description is  null)
            {
                var result = new CategoryViewModel { Description = "فیلد را پر کنید", Title = "فیلد را پر کنید" };
                ViewBag.category = result;
                ViewBag.ShowCategoryModal = true;
                ViewBag.Massage = "لطفا فیلد ها را پر کنید";
                return View("Dashboard");
            }

            return RedirectToAction("Dashboard");



        }




    }
}
