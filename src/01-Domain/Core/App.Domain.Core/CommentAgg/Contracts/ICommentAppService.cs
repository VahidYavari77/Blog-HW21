using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CommentAgg.Contracts
{
 public   interface ICommentAppService
    {
        public Task<Result<bool>> AddComment(CommentDto commentDto);
        public Task<Result<List<CommentDto>>> GetByPostId(int Id);
        public Task<Result<bool>> RejectedComment(int commentId);
        public Task<Result<bool>> ConfirmComment(int commentId);
    }
}
