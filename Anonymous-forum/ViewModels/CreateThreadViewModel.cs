using Anonymous_forum.Models;
using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.ViewModels
{
    public class CreateThreadViewModel
    {
        [Required(ErrorMessage = "Please type some text explaining your thread.")]
        public string? ThreadText { get; set; }
        [Required(ErrorMessage = "You have to give the thread a title.")]
        public string? ThreadTitle { get; set; }
        public int CategoryId { get; set; }
    }
}
