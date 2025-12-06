using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.EndPoints.MVC.Blog_HW21.Models.CategoryAgg;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.EndPoints.MVC.Blog_HW21.ViewComponents
{
   public class HeaderViewComponent(ICategoryAppService categoryAppService): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =await categoryAppService.GetMenuCategory();
            var menu = new List<MenuCategoryViewModel>();
            if (categories!=null&& categories.Data!=null)
            {
                
                foreach (var item in categories.Data)
                {
                    var menuca = new MenuCategoryViewModel
                    {
                        CategortName=item.CategortName,
                        CategoryId=item.CategoryId
                    };
                    menu.Add(menuca);
                }
               
            }
            else
            {
                var menuca = new MenuCategoryViewModel
                {
                    CategortName = "دسته بندی وجود ندارد",
                    CategoryId = 0
                };
                menu.Add(menuca);
            }

            return View("_Header", menu);
        }
    }
}
