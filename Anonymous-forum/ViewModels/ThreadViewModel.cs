using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class ThreadViewModel
    {
        [Required(ErrorMessage = "Please type some text explaining your thread.")]
        public string? ThreadText { get; set; }
        [Required(ErrorMessage = "You have to give the thread a title.")]
        public string? ThreadTitle { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        [Required(ErrorMessage = "Please add some text to your comment.")]
        public string? CommentText { get; set; }
        public List<Comments>? Comments {  get; set; }
    }
}