

using App.Domain.Core.AuthorAgg.Entities;

namespace App.EndPoints.MVC.Blog_HW21.Models.LocalStorage
{
    public static class InMemoryDb
    {
        public static int CurrentAuthorId { get; set; }
        public static Author CurrentAuthor { get; set; }
      



    }
}
