using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AuthorAgg.Contracts
{
    public interface IAuthorAppService
    {
        public Result<bool> AddAuthor(AuthorDto authorDto);
        public Result<Author> Login(LoginDto loginDto);
    }
}
