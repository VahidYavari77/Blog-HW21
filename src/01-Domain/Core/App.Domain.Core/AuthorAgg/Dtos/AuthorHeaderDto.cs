using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AuthorAgg.Dtos
{
 public   class AuthorHeaderDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountPost { get; set; }
        public int CountCategory { get; set; }
        public int CountComment { get; set; }
      
    }
}
