using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.AuthorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.Services.AuthorAgg
{
    public class AuthorService(IAuthorRepo authorRepo) : IAuthorService
    {
        public bool AddAuthor(Author author)
        {
            return authorRepo.AddAuthor(author);
        }

        public Author? Login(LoginDto loginDto)
        {
          return authorRepo.Login(loginDto);
        }
    }
}
