using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domin.Service.AppServices.CategoryAgg
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public Result<bool> AddCategory(CategoryDto _categorydto)
        {
            var category = new Category
            {
             Name= _categorydto.Name,
             Description= _categorydto.Description,

                AuthorId = _categorydto.AuthorId,
             CreateAt=DateTime.Now,
            };
            var result = categoryService.AddCategory(category);
            if (result)
            {
                return Result<bool>.Success("دسته بندی با موفقیت ثبت شد",true);
            }
            else
            {
                return Result<bool>.Failure("ثبت دسته بندی با خطا مواجه شد",false);
            }
        }

        public async Task<Result<bool>> DeleteCategory(int id)
        {
            var result = await categoryService.DeleteCategory(id);
            if (result)
            {
                return Result<bool>.Success("دسته بندی با موفقیت حذف شد", true);
            }
            else
            {
                return Result<bool>.Failure("حذف دسته بندی با خطا مواجه شد", false);
            }
        }

        public Result<List<CategoryDto>> GetByAuthorId(int Id)
        {
            var result = categoryService.GetByAuthorId(Id);

            if (result != null)
            {

                return Result<List<CategoryDto>>.Success("دسته بندی موجود است", result);
            }
            else
            {
                return Result<List<CategoryDto>>.Failure("دسته بندی موجود نیست");
            }
        }

        public Result<CategoryDto> GetCategoryById(int Id)
        {
            var result = categoryService.GetCategoryById(Id);
            if (result != null)
            {

                return Result<CategoryDto>.Success("دسته بندی موجود است", result);
            }
            else
            {
                return Result<CategoryDto>.Failure("دسته بندی موجود نیست");
            }

        }

        public async Task<Result<List<MenuCategoryDto>>> GetMenuCategory()
        {
            var result =await categoryService.GetMenuCategory();
            if (result != null)
            {

                return Result<List<MenuCategoryDto>>.Success(" لیست دسته بندی موجود است ", result);
            }
            else
            {
                return Result<List<MenuCategoryDto>>.Failure(" لیست دسته بندی موجود نیست");
            }
        }

        public async Task<Result<bool>> UpdateCategory(CategoryDto _categorydto)
        {

            var category = new Category
            {
                Name = _categorydto.Name,
                Description = _categorydto.Description,
                
                AuthorId = _categorydto.AuthorId,
                CreateAt = DateTime.Now,
                Id= _categorydto.CategoryId
            };
            var result = await categoryService.UpdateCategory(category);
            if (result)
            {
                return Result<bool>.Success("دسته بندی با موفقیت ویرایش شد", true);
            }
            else
            {
                return Result<bool>.Failure("ویرایش دسته بندی با خطا مواجه شد", false);
            }


        }
    }
}
