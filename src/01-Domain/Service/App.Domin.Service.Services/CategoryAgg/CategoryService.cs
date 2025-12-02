using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.Services.CategoryAgg
{
    public class CategoryService(ICategoryRepo categoryRepo) : ICategoryService
    {
        public bool AddCategory(Category category)
        {
            return categoryRepo.AddCategory(category);
        }
    }
}
