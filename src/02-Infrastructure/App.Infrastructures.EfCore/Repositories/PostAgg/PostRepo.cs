using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enum;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.PostAgg.Entities;
using App.Infrastructures.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.PostAgg
{
    public class PostRepo(AppDbContext appDbContext) : IPostRepo
    {
        public async Task<bool> AddPost(Post post)
        {
            try
            {
                appDbContext.Posts.Add(post);
               await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePost(int Id)
        {
            try
            {
                await appDbContext.Posts
                   .Where(p => p.Id == Id)
                   .ExecuteDeleteAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<PostDto>> GetAllPost()
        {
            var result = await appDbContext.Posts
      .Select(p => new PostDto
      {
          Text = p.Text,
          Title = p.Title,
          ImgUrl = p.ImgUrl,
          CategoryId = p.CategoryId,
          AuthorId = p.AuthorId,
          AuthorName = p.Author.FirstName + " " + p.Author.LastName,
          CategoryName = p.Category.Name,
          CreatAt = p.CreateAt,
          PostId = p.Id,

          commentDtos = p.Comments.Where(c => c.OpinionStatus == OpinionStatusEnum.Approved).Select(c => new CommentDto
          {
              CommentId = c.Id,
              CommentText = c.CommentText,
              UserFirstName = c.UserFirstName,
              CreateAT = c.CreateAt,
              Email=c.Email,
              OpinionStatus=c.OpinionStatus,
              UserLastName=c.UserLastName,
              PostId=c.PostId,
              Rate=c.Rate,
              
              
          }).ToList()
      })
      .ToListAsync();
            return result;
        }

        public async Task<List<PostDto>> GetByAuthorId(int Id)
        {
            var result = await appDbContext.Posts.Where(p => p.AuthorId == Id).Select(p=>new PostDto
            {
                Text=p.Text,Title=p.Title,ImgUrl=p.ImgUrl,CategoryId=p.CategoryId,AuthorId=p.AuthorId,
                AuthorName =
                p.Author.FirstName+" "+p.Author.LastName,CategoryName=p.Category.Name,CreatAt=p.CreateAt,
                PostId=p.Id
            }).ToListAsync();
            return result;
        }

        public async Task<PostDto> GetPostById(int Id)
        {
            var result = await appDbContext.Posts.Where(p => p.Id == Id).Select(p => new PostDto
            {
                PostId = p.Id, AuthorId = p.AuthorId, CategoryId = p.CategoryId, CategoryName = p.Category.Name,
                CreatAt = p.CreateAt, AuthorName = p.Author.FirstName + " " + p.Author.LastName, ImgUrl = p.ImgUrl,
                Text = p.Text, Title = p.Title,
                commentDtos = p.Comments.Select(c => new CommentDto
                {
                    CommentId = c.Id,
                    CommentText = c.CommentText,
                    UserFirstName = c.UserFirstName,
                    CreateAT = c.CreateAt,
                    Email = c.Email,
                    OpinionStatus = c.OpinionStatus,
                    UserLastName = c.UserLastName,
                    PostId = c.PostId,
                    Rate = c.Rate,


                }).ToList()

            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdatePost(PostDto postDto)
        {
            try
            {
                await appDbContext.Posts
             .Where(p => p.Id == postDto.PostId)
             .ExecuteUpdateAsync(s => s
             .SetProperty(p => p.Title, $"{postDto.Title}")
             .SetProperty(p => p.Text, $"{postDto.Text}")
             .SetProperty(p => p.ImgUrl, $"{postDto.ImgUrl}"));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
