using App.Domain.Core.CategoryAgg.Contracts;
using App.Infrastructures.EfCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.CategoryAgg
{
 public   class CategoryRepo(AppDbContext appDbContext) : ICategoryRepo
    {
    }
}
