using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.Services.CommentAgg
{
    public class CommentService(ICommentRepo commentRepo) : ICommentService
    {
        public Task<bool> AddComment(Comment comment)
        {
            return commentRepo.AddComment(comment);
        }

        public async Task<bool> ConfirmComment(int commentId)
        {
         return  await commentRepo.ConfirmComment(commentId);
        }

        public async Task<List<CommentDto>> GetByPostId(int Id)
        {
            return await commentRepo.GetByPostId(Id);
        }

        public async Task<bool> RejectedComment(int commentId)
        {
            return await commentRepo.RejectedComment(commentId);
        }
    }
}
