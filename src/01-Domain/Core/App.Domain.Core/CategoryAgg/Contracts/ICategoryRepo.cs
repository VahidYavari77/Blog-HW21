using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Contracts
{
   public interface ICategoryRepo
    {
        public bool AddCategory(Category category);
        public List<CategoryDto> GetByAuthorId(int Id);
        public CategoryDto GetCategoryById(int Id);
        public Task<bool> UpdateCategory(Category category);
        public  Task<bool> DeleteCategory(int id);
        public Task<List<MenuCategoryDto>> GetMenuCategory();


    }
}
