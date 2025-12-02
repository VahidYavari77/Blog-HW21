using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.Utilities;
using App.Domin.Service.Services.AuthorAgg;
using Blog_HW21._Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.AppServices.AuthorAgg
{
    public class AuthorAppService(IAuthorService authorService) : IAuthorAppService
    {
        public Result<bool> AddAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                FirstName= authorDto.FirstName,
                LastName= authorDto.LastName,
                UserName= authorDto.UserName,
                Password= authorDto.Password.ToMd5Hex(),
                Email= authorDto.Email,
                CreateAt=DateTime.Now
            };
            var result = authorService.AddAuthor(author);
            if (result)
                return Result<bool>.Success("ثبت نام موفق", true);
            else
                return Result<bool>.Success("ثبت نام ناموفق", false);

        }

        public Result<Author> Login(LoginDto loginDto)
        {
            var result = authorService.Login(loginDto);
            if (result is null)
            {
                return Result<Author>.Failure("اطلاعات وارد شده صحیح نمیباشد");
            }
            else
            {
                return Result<Author>.Success("اطلاعات وارد شده صحیح است", result);
            }
        }
    }
}
