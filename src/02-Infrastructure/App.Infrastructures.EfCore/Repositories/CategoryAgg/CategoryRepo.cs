using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infrastructures.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public List<CategoryDto> GetByAuthorId(int Id)
        {
            var result = appDbContext.Categories.Where(c => c.AuthorId == Id).Select(p => new CategoryDto
            {
                Name = p.Name,
                Description = p.Description,
                AuthorId = p.AuthorId,
                CountPost =p.Posts.Count,
                CategoryId=p.Id

            }).ToList();
            return result;
        }

        public CategoryDto GetCategoryById(int Id)
        {
            var result = appDbContext.Categories.Where(c => c.Id == Id).Select(c => new CategoryDto
            {
                Description = c.Description,
                Name = c.Name,
                CategoryId = c.Id
            }).FirstOrDefault();
            return result;

        }

        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
               await appDbContext.Categories
            .Where(c => c.Id == category.Id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(c => c.Name, $"{category.Name}")
            .SetProperty(c => c.Description, $"{category.Description}")
                          );
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                await appDbContext.Categories
                   .Where(c => c.Id == id)
                   .ExecuteDeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<MenuCategoryDto>> GetMenuCategory()
        {
          return await  appDbContext.Categories.Select(c => new MenuCategoryDto
            {
                CategortName=c.Name,
                CategoryId=c.Id
            }).ToListAsync();
            
        }
    }
}
