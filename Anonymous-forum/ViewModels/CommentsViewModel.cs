using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class CommentsViewModel
    {
        [Required(ErrorMessage = "Please add some text to your comment.")]
        public string? CommentText { get; set; }
    }
}
