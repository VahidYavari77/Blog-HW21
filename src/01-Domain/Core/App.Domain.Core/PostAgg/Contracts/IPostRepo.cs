
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.Contracts
{
   public interface IPostRepo
    {
        public Task<bool> AddPost(Post post);
        public Task<List<PostDto>> GetByAuthorId(int Id);
        public Task<List<PostDto>> GetAllPost();
        public Task<bool> DeletePost(int Id);
        public Task<PostDto> GetPostById(int Id);
        public Task<bool> UpdatePost(PostDto postDto);

    }
}
