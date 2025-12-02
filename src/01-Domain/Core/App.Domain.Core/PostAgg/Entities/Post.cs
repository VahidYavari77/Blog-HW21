using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Domain.Core.PostAgg.Entities
{
  public  class Post:BaseEntity
    {
  
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
       
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
