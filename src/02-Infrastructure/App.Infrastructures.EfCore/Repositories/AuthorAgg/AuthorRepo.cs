using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.AuthorAgg.Entities;
using App.Infrastructures.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.AuthorAgg
{
  public  class AuthorRepo(AppDbContext appDbContext) : IAuthorRepo
    {
        public bool AddAuthor(Author author)
        {
            try
            {
                appDbContext.Authors.Add(author);
                appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AuthorHeaderDto? GetAuthorHeaderDto(int AuthorId)
        {
            var author = appDbContext.Authors
       .Where(a => a.Id == AuthorId)
       .Select(a => new AuthorHeaderDto
       {
           FirstName = a.FirstName,
           LastName = a.LastName,
           CountPost = a.Posts.Count,
           CountCategory = a.Categories.Count,
           CountComment = a.Posts.SelectMany(p => p.Comments).Count()
       })
       .FirstOrDefault();

            return author;
        }

        public Author? Login(LoginDto loginDto)
        {
            var author = appDbContext.Authors
              
                .FirstOrDefault(a => a.UserName == loginDto.UserName && a.Password == loginDto.Password);

            return author; 
        }


    }
}
