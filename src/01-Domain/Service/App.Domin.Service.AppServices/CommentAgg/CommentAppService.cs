using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.Utilities;
using App.Domin.Service.Services.PostAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domin.Service.AppServices.CommentAgg
{
    public class CommentAppService(ICommentService commentService) : ICommentAppService
    {
        public async Task<Result<bool>> AddComment(CommentDto commentDto)
        {
            var comment = new Comment
            {
                
                CreateAt = commentDto.CreateAT,
                CommentText = commentDto.CommentText,
                Email = commentDto.Email,
                OpinionStatus = commentDto.OpinionStatus,
                PostId = commentDto.PostId,
                UserFirstName = commentDto.UserFirstName,
                Rate = commentDto.Rate,
                UserLastName = commentDto.UserLastName
            };
            var result = await commentService.AddComment(comment);
            if (result)
            {
                return Result<bool>.Success(" کامنت با موفقیت ویرایش شد", true);
            }
            else
            {
                return Result<bool>.Failure(" کامنت  با خطا مواجه شد");
            }
        }

        public async Task<Result<bool>> ConfirmComment(int commentId)
        {
            var result = await commentService.ConfirmComment(commentId);
            if (result)
            {
                return Result<bool>.Success(" کامنت با موفقیت تایید شد", true);
            }
            else
            {
                return Result<bool>.Failure(" خطا در تایید کامنت  ");
            }
        }

        public async Task<Result<List<CommentDto>>> GetByPostId(int Id)
        {
           var commentList =   await commentService.GetByPostId(Id);
            if (commentList != null)
            {
                return Result<List<CommentDto>>.Success("لیست کامنت ها با موفقیت گرفته شد", commentList);
            }
            else
            {
                return Result<List<CommentDto>>.Failure("خطا دز گرفتن لیست کامنت ها");
            }
        }

        public async Task<Result<bool>> RejectedComment(int commentId)
        {
            var result = await commentService.RejectedComment(commentId);
            if (result)
            {
                return Result<bool>.Success(" کامنت با موفقیت رد شد", true);
            }
            else
            {
                return Result<bool>.Failure(" خطا در رد کامنت ");
            }
        }
    }
}
