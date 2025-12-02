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

        public Author? Login(LoginDto loginDto)
        {
            var author = appDbContext.Authors
                .Include(a => a.Categories)
                    .ThenInclude(p => p.Posts)
                .FirstOrDefault(a => a.UserName == loginDto.UserName && a.Password == loginDto.Password);

            return author; 
        }


    }
}
