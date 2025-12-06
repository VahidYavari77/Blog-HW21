using App.Domain.Core.CommentAgg.Dtos;

namespace App.EndPoints.MVC.Blog_HW21.Models.Post
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public IFormFile Img { get; set; }
        public string CreatAt { get; set; }
       public List<CommentDto> commentDtos { get; set; } = [];
        public string CreateAt { get; set; }
        public string CommentCreatAT { get; set; }
    }
}
