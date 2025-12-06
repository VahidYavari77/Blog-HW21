using App.Domain.Core.AuthorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountPost { get; set; } 
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
