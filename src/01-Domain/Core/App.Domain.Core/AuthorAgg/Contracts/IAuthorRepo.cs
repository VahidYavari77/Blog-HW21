using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.AuthorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AuthorAgg.Contracts
{
  public  interface IAuthorRepo
    {
        public bool AddAuthor(Author author);
        public Author? Login(LoginDto loginDto);
        public AuthorHeaderDto? GetAuthorHeaderDto(int AuthorId);

    }
}
