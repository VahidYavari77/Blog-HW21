using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.EndPoints.MVC.Blog_HW21.Models;
using App.Domain.Core.AuthorAgg.Entities;
using App.EndPoints.MVC.Blog_HW21.Models.AuthorAgg;
using App.EndPoints.MVC.Blog_HW21.Models.LocalStorage;
using App.Domain.Core.PostAgg.Contracts;
using App.EndPoints.MVC.Blog_HW21.Models.Post;
using System.Threading.Tasks;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;

namespace App.EndPoints.MVC.Blog_HW21.Controllers;

public class HomeController (IPostAppService postAppService, ICommentAppService commentAppService): Controller
{
    //private readonly ILogger<HomeController> _logger;

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}


    public async Task<IActionResult> Index(string filter)
    {
        if (filter == null)
        {
            filter = "all";
        }

        var post = await postAppService.GetAllPost();
        var posts = new List<PostViewModel>();
        if (post.Data is not null && post is not null)
        {
            
            foreach (var item in post.Data)
            {
                
              
                var postview = new PostViewModel
                {
                    AuthorId = item.AuthorId,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    AuthorName = item.AuthorName,
                    Text = item.Text,
                    Title = item.Title,
                    ImgUrl = item.ImgUrl,
                    CreatAt = DateTimeExtensions.ToShamsi(item.CreatAt),
                    PostId = item.PostId,
                    CreateAt = item.CreatAt.ToShamsi(),
                    commentDtos=item.commentDtos,
                    

                };
                posts.Add(postview);
            }
        }
        else
        {
            posts = new List<PostViewModel>();
        }
        
        string filterCategoryName = filter;
        var filteredPosts = new List<PostViewModel>();
      
        if(filter=="all"&&posts!=null)
        {

            filteredPosts = posts;
        }
        if (filter == null && posts != null)
        {

            filteredPosts = posts;
        }
        if (posts.Any(p => p.CategoryName == filterCategoryName) && posts != null)
        {
            filteredPosts = posts.Where(p => p.CategoryName == filterCategoryName).ToList();

        }
        else if(filter!="all")
        {
            filteredPosts= default;
        }






        return View(filteredPosts);
    }
    public async Task<IActionResult> PostContent( int id)
    {
        var post =await postAppService.GetPostById(id);
        if (post!=null&& post.Data != null)
        {
            var postview = new PostViewModel
            {
                AuthorId = post.Data.AuthorId,
                CategoryId = post.Data.CategoryId,
                CategoryName = post.Data.CategoryName,
                AuthorName = post.Data.AuthorName,
                Text = post.Data.Text,
                Title = post.Data.Title,
                ImgUrl = post.Data.ImgUrl,
                CreatAt = DateTimeExtensions.ToShamsi(post.Data.CreatAt),
                PostId = post.Data.PostId,
                CreateAt = post.Data.CreatAt.ToShamsi(),
                commentDtos = post.Data.commentDtos,


            };
            return View(postview);
        }
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
