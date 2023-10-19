using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class CommentsViewModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Please add some text to your comment.")]
        public string? CommentText { get; set; }
        public int ThreadId { get; set; }
    }
}
