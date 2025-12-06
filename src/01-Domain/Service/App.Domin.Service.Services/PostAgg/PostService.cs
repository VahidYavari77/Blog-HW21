using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.Services.PostAgg
{
    public class PostService(IPostRepo postRepo) : IPostService
    {


        public async Task<bool> AddPost(Post post)
        {
            return await postRepo.AddPost(post);
        }

        public async Task<bool> DeletePost(int Id)
        {
            return await postRepo.DeletePost(Id);
        }

        public async Task<List<PostDto>> GetAllPost()
        {
            return await postRepo.GetAllPost();
        }

        public async Task<List<PostDto>> GetByAuthorId(int Id)
        {
            return await postRepo.GetByAuthorId(Id);
        }

        public async Task<PostDto> GetPostById(int Id)
        {
            return await postRepo.GetPostById(Id);
        }

        public async Task<bool> UpdatePost(PostDto postDto)
        {
            return await postRepo.UpdatePost(postDto);
        }
    }
}
