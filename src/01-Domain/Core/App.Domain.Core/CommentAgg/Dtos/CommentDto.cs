using App.Domain.Core.CommentAgg.Enum;
using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CommentAgg.Dtos
{
   public class CommentDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        [Range(1, 5)]
        public float Rate { get; set; }
        public int MyProperty { get; set; }
        public OpinionStatusEnum OpinionStatus { get; set; }
        public int CommentId { get; set; }
        public DateTime CreateAT  { get; set; }
        public DateTime UpdateAt  { get; set; }

        public int PostId { get; set; }
    }
}
