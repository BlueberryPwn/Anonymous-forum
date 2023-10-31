using Anonymous_forum.Models;
using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.ViewModels
{
    public class CreateCommentViewModel
    {
        [Required(ErrorMessage = "Please type something before submitting your comment.")]
        public string? CommentText { get; set; }
        public int ThreadId { get; set; }
    }
}
