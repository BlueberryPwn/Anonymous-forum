using System.ComponentModel.DataAnnotations;

namespace AnonymousForum.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public int ThreadId { get; set; }
    }
}
