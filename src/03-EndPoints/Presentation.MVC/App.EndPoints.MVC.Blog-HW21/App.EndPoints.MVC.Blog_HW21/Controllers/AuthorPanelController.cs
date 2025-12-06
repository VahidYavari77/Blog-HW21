
using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.PostAgg.Entities;
using App.EndPoints.MVC.Blog_HW21.Models;
using App.EndPoints.MVC.Blog_HW21.Models.AuthorAgg;
using App.EndPoints.MVC.Blog_HW21.Models.Category;
using App.EndPoints.MVC.Blog_HW21.Models.CategoryAgg;
using App.EndPoints.MVC.Blog_HW21.Models.Comment;
using App.EndPoints.MVC.Blog_HW21.Models.Dashboard;
using App.EndPoints.MVC.Blog_HW21.Models.LocalStorage;
using App.EndPoints.MVC.Blog_HW21.Models.Post;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Threading.Tasks;

namespace App.EndPoints.MVC.Blog_HW21.Controllers
{
    public class AuthorPanelController(IPostAppService postAppService,
        ICategoryAppService categoryAppService, IAuthorAppService authorAppService,
        ICommentAppService commentAppService) : Controller
    {

        public async Task<IActionResult> AuthorPanel()
        {


            var authorHeader = authorAppService.GetAuthorHeaderDto(InMemoryDb.CurrentAuthorId);
            if (authorHeader.Data != null && authorHeader != null)
            {
                var authorHeaderview = new HederDashboardViewModel
                {
                    CountCategory = authorHeader.Data.CountCategory,
                    CountComment = authorHeader.Data.CountComment,
                    CountPost = authorHeader.Data.CountPost,
                    FullName = authorHeader.Data.FirstName + " " + authorHeader.Data.LastName,
                    NameAbbreviation = Abbreviation.GetInitials(authorHeader.Data.FirstName + " " + authorHeader.Data.LastName)

                };
                ViewBag.header = authorHeaderview;
            }
            var categories1 = categoryAppService.GetByAuthorId(InMemoryDb.CurrentAuthorId);
            var categories = new List<CategoryViewModel>();
            if (categories1 != null && categories1.Data != null)
            {
                foreach (var item in categories1.Data)
                {
                    var a = new CategoryViewModel { CountPost = item.CountPost, Description = item.Description, CategoryId = item.CategoryId,
                        Title = item.Name };
                    categories.Add(a);
                }
                ViewBag.Catrgories = categories;
            }
            var posts = await postAppService.GetByAuthorId(InMemoryDb.CurrentAuthorId);
            if (posts.Data is not null && posts is not null)
            {
                List<PostViewModel> postViews = new List<PostViewModel>();
                foreach (var item in posts.Data)
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
                        PostId = item.PostId
                    };
                    postViews.Add(postview);
                }
                ViewBag.Posts = postViews;
            }



            return View();
        }

        public IActionResult Logout()
        {
            InMemoryDb.CurrentAuthorId = default;
            InMemoryDb.CurrentAuthor = default;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult CreateCategories(AddCategoryViewModel model)
        {

            if (model.Ti0 is not null && model.De0 is not null)
            {
                var categorydto = new CategoryDto
                {

                    AuthorId = InMemoryDb.CurrentAuthorId,
                    Name = model.Ti0,
                    Description = model.De0

                };
                var result = categoryAppService.AddCategory(categorydto);
                if (result.Data == false || result.IsSuccess == false)
                {
                    ViewBag.Massage = result.Message;
                    return View("AuthorPanel");
                }
                else
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction("AuthorPanel");
                }
            }
            if (model.Ti0 is null || model.De0 is null)
            {
                //var result = new AddCategoryViewModel { De0 = "فیلد را پر کنید", Ti0 = "فیلد را پر کنید" };
                //ViewBag.categoryfailed = result;
                ViewBag.ShowCategoryModal = true;
                ViewBag.ERCA = "لطفا فیلد ها را پر کنید";
                return View("AuthorPanel");
            }

            return RedirectToAction("AuthorPanel");



        }
        [HttpGet]
        public IActionResult EditCategories(int id)
        {
            var result = categoryAppService.GetCategoryById(id);
            if (result is not null && result.Data is not null)
            {
                var editca = new CategoryViewModel
                {
                    Title = result.Data.Name,
                    Description = result.Data.Description,
                    CategoryId = result.Data.CategoryId

                };



                return View("EditCategories", editca);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditCategories(CategoryViewModel model)
        {
            var cadto = new CategoryDto { CategoryId = model.CategoryId, Name = model.Title, Description = model.Description };
            var result = await categoryAppService.UpdateCategory(cadto);
            if (result.Data)
            {
                //ViewBag.masca = $"{result.Message} || {model.Title} <= دسته بندی";
                return RedirectToAction("AuthorPanel");
            }

            return View("EditCategories", model);
        }

        public async Task<IActionResult> DeleteCategories(int id)
        {
            var resultDe = await categoryAppService.DeleteCategory(id);
            if (resultDe.Data)
            {

                return RedirectToAction("AuthorPanel");
            }
            ViewBag.masade = resultDe.Message;
            return RedirectToAction("AuthorPanel");
        }
        [HttpPost]
        public async Task<IActionResult> CreatPost(PostViewModel postView)
        {

            var postdto = new PostDto
            {
                Text = postView.Text, Title = postView.Title, CategoryId = postView.CategoryId,
                AuthorId = InMemoryDb.CurrentAuthorId, ImgUrl = FileService.Upload(postView.Img)
            };
            var res = await postAppService.AddPost(postdto);
            return RedirectToAction("AuthorPanel");
        }
        public async Task<IActionResult> DeletePost(int id)
        {
            var resultDe = await postAppService.DeletePost(id);
            if (resultDe.Data)
            {

                return RedirectToAction("AuthorPanel");
            }
            ViewBag.masade = resultDe.Message;
            return RedirectToAction("AuthorPanel");

            //return RedirectToAction("AuthorPanel");
        }
        public  async Task<IActionResult> EditPost(int id)
        {
            var categories1 = categoryAppService.GetByAuthorId(InMemoryDb.CurrentAuthorId);
            var categories = new List<CategoryViewModel>();
            if (categories1 != null && categories1.Data != null)
            {
                foreach (var item in categories1.Data)
                {
                    var a = new CategoryViewModel
                    {
                        CountPost = item.CountPost,
                        Description = item.Description,
                        CategoryId = item.CategoryId,
                        Title = item.Name
                    };
                    categories.Add(a);
                }
                ViewBag.Catrgories = categories;
            }

            var post = await postAppService.GetPostById(id);
            if (post.Data is not null && post is not null)
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
                        PostId = post.Data.PostId
                    };
                ViewBag.Posts = postview;
                return View(postview);
                
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(PostViewModel model)
        {
            var postVM = new PostDto
            {
                Text = model.Text,
                Title = model.Title,
                ImgUrl = (model.Img == null) ? model.ImgUrl : FileService.Upload(model.Img),
                CategoryId = model.CategoryId,
                PostId = model.PostId

            };
           var result= postAppService.UpdatePost(postVM);
            return RedirectToAction("AuthorPanel");
        }
      
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel commentViewModel)
        {
            var commentDto = new CommentDto
            {
                PostId = commentViewModel.PostId,
                CommentText = commentViewModel.CommentText,
                CreateAT =DateTime.Now,
                Email = commentViewModel.Email,
                Rate = commentViewModel.Rate,
                UserFirstName = commentViewModel.UserFirstName,
                UserLastName = commentViewModel.UserLastName,


            };
            var result =await commentAppService.AddComment(commentDto);
          return  RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> ManageComments(int id, CommentStatusViewModel statusViewModel)
        {
            if ( statusViewModel is not null)
            {
               
                if (statusViewModel.Status == "A")
                {
                    var status = commentAppService.ConfirmComment(statusViewModel.CommentId);
                }
                if (statusViewModel.Status == "R")
                {
                    var status = commentAppService.RejectedComment(statusViewModel.CommentId);
                }


            }

            var post = await postAppService.GetPostById(id);
            if (post != null && post.Data != null)
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
            return RedirectToAction("AuthorPanel");
        }
        //public async Task<IActionResult> CommentStatus(int id)
        //{

        //}
    }
}