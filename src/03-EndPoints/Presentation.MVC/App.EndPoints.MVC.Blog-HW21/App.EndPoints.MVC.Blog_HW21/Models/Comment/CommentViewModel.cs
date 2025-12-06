using App.Domain.Core.CommentAgg.Enum;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.Blog_HW21.Models.Comment
{
    public class CommentViewModel
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        
        public OpinionStatusEnum OpinionStatus { get; set; }
        public int CommentId { get; set; }
        public DateTime CreateAT { get; set; }
        public DateTime UpdateAt { get; set; }

        public int PostId { get; set; }
    }
}
