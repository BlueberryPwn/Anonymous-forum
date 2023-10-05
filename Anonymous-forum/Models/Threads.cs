using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class Threads
    {
        [Key]
        public int ThreadId { get; set; }
        public string? ThreadText { get; set; }
        public string? ThreadTitle { get; set; }
        public int CategoryId { get; set; }
    }
}
