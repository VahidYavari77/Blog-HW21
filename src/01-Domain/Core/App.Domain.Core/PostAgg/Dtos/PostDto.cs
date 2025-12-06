using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.Dtos
{
  public  class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
      
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public  string CategoryName { get; set; }
        public  string AuthorName { get; set; }
        public DateTime CreatAt { get; set; }
        public List<CommentDto> commentDtos { get; set; } = [];

    }
}
