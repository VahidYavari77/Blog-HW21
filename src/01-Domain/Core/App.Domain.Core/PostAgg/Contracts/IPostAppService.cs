using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.Contracts
{
    public interface IPostAppService
    {
        public Task<Result<bool>> AddPost(PostDto postDto);
        public Task<Result<List<PostDto>>> GetByAuthorId(int Id);
        public Task<Result<bool>> DeletePost(int Id);
        public Task<Result<PostDto>> GetPostById(int Id);
        public Task<Result<bool>> UpdatePost(PostDto postDto);
        public Task<Result<List<PostDto>>> GetAllPost();
    }
}
