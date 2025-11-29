using App.Domain.Core.AuthorAgg.Contracts;
using App.Domin.Service.Services.AuthorAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.AppServices.AuthorAgg
{
  public  class AuthorAppService(IAuthorService authorService): IAuthorAppService
    {
        
    }
}
