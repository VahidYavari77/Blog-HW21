using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.CommentAgg.Enum;
using App.Domain.Core.PostAgg.Dtos;
using App.Infrastructures.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.CommentAgg
{
    public class CommentRepo(AppDbContext appDbContext) : ICommentRepo
    {
        public async Task<bool> AddComment(Comment comment)
        {
            try
            {
                comment.CreateAt = DateTime.Now;
                await appDbContext.Comments.AddAsync(comment);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ConfirmComment(int commentId)
        {
            try
            {
                
                await appDbContext.Comments
               .Where(c => c.Id == commentId)
               .ExecuteUpdateAsync(s => s
               .SetProperty(c => c.OpinionStatus, OpinionStatusEnum.Approved));
        
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CommentDto>> GetByPostId(int Id)
        {
            
                var coments = await appDbContext.Comments.Where(p => p.PostId == Id).Select(c => new CommentDto
                {
                    CommentId = c.Id,
                    CreateAT = c.CreateAt,
                    CommentText = c.CommentText,
                    Email = c.Email,
                    OpinionStatus = c.OpinionStatus,
                    PostId = c.PostId,
                    UserFirstName = c.UserFirstName,
                    Rate = c.Rate,
                    UserLastName = c.UserLastName

                }).ToListAsync();
                return coments;
           
        }

        public async Task<bool> RejectedComment(int commentId)
        {
            try
            {

                await appDbContext.Comments
               .Where(c => c.Id == commentId)
               .ExecuteUpdateAsync(s => s
               .SetProperty(c => c.OpinionStatus, OpinionStatusEnum.Rejected));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
