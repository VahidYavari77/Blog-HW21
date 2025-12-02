using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infrastructures.EfCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.CategoryAgg
{
    public class CategoryRepo(AppDbContext appDbContext) : ICategoryRepo
    {
        public bool AddCategory(Category category)
        {
            try
            {
                appDbContext.Categories.Add(category);
                appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
