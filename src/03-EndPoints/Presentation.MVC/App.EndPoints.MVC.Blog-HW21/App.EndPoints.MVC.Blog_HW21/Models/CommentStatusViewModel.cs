namespace App.EndPoints.MVC.Blog_HW21.Models
{
    public class CommentStatusViewModel
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Status { get; set; }
    }
}
