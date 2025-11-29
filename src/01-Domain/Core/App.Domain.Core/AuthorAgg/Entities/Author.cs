using App.Domain.Core.AuthorAgg.ValueObject;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AuthorAgg.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public bool Rules { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }



    }
}
