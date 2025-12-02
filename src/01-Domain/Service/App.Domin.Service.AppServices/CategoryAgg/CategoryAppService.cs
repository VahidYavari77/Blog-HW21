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
             
             AuthorId= _categorydto.AuthorId,
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
    }
}
