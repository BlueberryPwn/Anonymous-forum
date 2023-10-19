using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class ThreadsViewModel
    {
        [Required(ErrorMessage = "Please type some text explaining your thread.")]
        public string? ThreadText { get; set; }
        [Required(ErrorMessage = "You have to give the thread a title.")]
        public string? ThreadTitle { get; set; }
    }
}
