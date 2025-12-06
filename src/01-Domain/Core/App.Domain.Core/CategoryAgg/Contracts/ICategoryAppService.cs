using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Contracts
{
  public  interface ICategoryAppService
    {
        public Result<bool> AddCategory(CategoryDto _category);
        public Result<List<CategoryDto>> GetByAuthorId(int Id);
        public Result<CategoryDto> GetCategoryById(int Id);
       
        public Task<Result<bool>> UpdateCategory(CategoryDto category);
        public Task<Result<bool>> DeleteCategory(int id);
        public Task<Result<List<MenuCategoryDto>>> GetMenuCategory();
    }
}
