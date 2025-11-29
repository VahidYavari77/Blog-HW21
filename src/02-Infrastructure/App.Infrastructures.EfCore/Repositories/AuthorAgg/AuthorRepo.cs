using App.Domain.Core.AuthorAgg.Contracts;
using App.Infrastructures.EfCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.AuthorAgg
{
  public  class AuthorRepo(AppDbContext appDbContext) : IAuthorRepo
    {
    }
}
