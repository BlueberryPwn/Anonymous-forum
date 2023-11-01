using AnonymousForum.Models;
using System.ComponentModel.DataAnnotations;

namespace AnonymousForum.ViewModels
{
    public class CreateCommentViewModel
    {
        [Required(ErrorMessage = "Please type something before submitting your comment.")]
        public string? CommentText { get; set; }
        public int ThreadId { get; set; }
    }
}
