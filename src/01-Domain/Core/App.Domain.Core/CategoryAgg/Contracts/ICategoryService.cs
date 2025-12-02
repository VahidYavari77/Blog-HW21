using App.Domain.Core.CategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Contracts
{
   public interface ICategoryService
    {
        public bool AddCategory(Category category);
    }
}
