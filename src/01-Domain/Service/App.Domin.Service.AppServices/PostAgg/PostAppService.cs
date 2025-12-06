using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.Utilities;
using App.Domin.Service.Services.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.AppServices.PostAgg
{
    public class PostAppService(IPostService postService) : IPostAppService
    {
        public async Task<Result<bool>> AddPost(PostDto postDto)
        {
            var post = new Post
            {
                AuthorId=postDto.AuthorId,
                CategoryId=postDto.CategoryId,
                Title=postDto.Title,
                Text=postDto.Text,
                ImgUrl=postDto.ImgUrl,
                CreateAt=DateTime.Now
               
            };

            var res = await postService.AddPost(post);
            if (res)
            {
                return Result<bool>.Success("پست با موفقیت ثبت شد",true);
            }
            else
            {
                return Result<bool>.Failure("خطا در ثبت پست");
            }

        }

        public async Task<Result<bool>> DeletePost(int Id)
        {
            var result = await postService.DeletePost(Id);
            if (result)
            {
                return Result<bool>.Success(" پست با موفقیت حذف شد", true);
            }
            else
            {
                return Result<bool>.Failure("حذف پست با خطا مواجه شد", false);
            }
        }

        public async Task<Result<List<PostDto>>> GetAllPost()
        {
            var result = await postService.GetAllPost();
            if (result != null)
            {
                return Result<List<PostDto>>.Success("دریافت لیست موفق", result);
            }
            else
            {
                return Result<List<PostDto>>.Failure("دریافت لیست ناموفق");
            }
        }

        public async Task<Result<List<PostDto>>> GetByAuthorId(int Id)
        {
            var result = await postService.GetByAuthorId(Id);
            if (result!=null)
            {
                return Result<List<PostDto>>.Success("دریافت لیست موفق",result);
            }
            else
            {
                return Result<List<PostDto>>.Failure("دریافت لیست ناموفق");
            }

        }

        public async Task<Result<PostDto>> GetPostById(int Id)
        {
            var result = await postService.GetPostById(Id);
            if (result != null)
            {
                return Result<PostDto>.Success("دریافت پست موفق", result);
            }
            else
            {
                return Result<PostDto>.Failure("دریافت پست ناموفق");
            }
        }

        public async Task<Result<bool>> UpdatePost(PostDto postDto)
        {
            var result = await postService.UpdatePost(postDto);
            if (result)
            {
                return Result<bool>.Success(" پست با موفقیت ویرایش شد", true);
            }
            else
            {
                return Result<bool>.Failure(" پست بندی با خطا مواجه شد");
            }
        }
    }
}
