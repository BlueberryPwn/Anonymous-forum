using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class CommentsViewModel
    {
        public string? ThreadText { get; set; }
        public string? ThreadTitle { get; set; }
        [Required(ErrorMessage = "Please add some text to your comment.")]
        public string? CommentText { get; set; }
    }
}
