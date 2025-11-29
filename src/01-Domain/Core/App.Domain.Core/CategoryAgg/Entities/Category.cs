using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Entities
{
   public class Category:BaseEntity
    {
        public string Name { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Post> Posts { get; set; }


    }
}
