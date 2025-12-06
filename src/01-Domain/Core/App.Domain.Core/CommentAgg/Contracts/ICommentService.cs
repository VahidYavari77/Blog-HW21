using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CommentAgg.Contracts
{
   public interface ICommentService
    {
        public Task<bool> AddComment(Comment comment);
        public Task<List<CommentDto>> GetByPostId(int Id);
        public Task<bool> RejectedComment(int commentId);
        public Task<bool> ConfirmComment(int commentId);
    }
}
