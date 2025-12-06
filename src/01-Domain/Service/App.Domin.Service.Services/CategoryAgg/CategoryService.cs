using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
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

        public async Task<bool> DeleteCategory(int id)
        {
            return await categoryRepo.DeleteCategory(id);
        }

        public List<CategoryDto> GetByAuthorId(int Id)
        {
            return categoryRepo.GetByAuthorId(Id);
        }

        public CategoryDto GetCategoryById(int Id)
        {
            return categoryRepo.GetCategoryById(Id);
        }

        public async Task<List<MenuCategoryDto>> GetMenuCategory()
        {
            return await categoryRepo.GetMenuCategory();
        }

    

        public  async Task<bool> UpdateCategory(Category category)
        {
            return await categoryRepo.UpdateCategory(category);
        }
    }
}
