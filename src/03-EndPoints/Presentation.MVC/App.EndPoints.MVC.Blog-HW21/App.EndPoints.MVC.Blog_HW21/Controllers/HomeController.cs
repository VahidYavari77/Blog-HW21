using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.MVC.Blog_HW21.Models;
using App.Domain.Core.AuthorAgg.Entities;
using App.EndPoints.MVC.Blog_HW21.Models.AuthorAgg;
using App.EndPoints.MVC.Blog_HW21.Models.LocalStorage;

namespace App.EndPoints.MVC.Blog_HW21.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var user = new Author
        {
            Id = 1,
            FirstName = "Vahid",
            LastName = "Yavari",
            Email = "vahid@example.com",
            UserName = "vahid123",
            Password = "123"
        };
        InMemoryDb.CurrentAuthor = user;
        InMemoryDb.CurrentAuthorId = user.Id;
        return View();
    }

  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
