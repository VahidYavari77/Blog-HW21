using App.EndPoints.MVC.Blog_HW21.Models.Category;

namespace App.EndPoints.MVC.Blog_HW21.Models.Dashboard
{
    public class DashboardViewModel
    {
        public List<CategoryViewModel>? Catrgories { get; set; }
       public  HederDashboardViewModel? HederDashboard { get; set; }

    }
}
