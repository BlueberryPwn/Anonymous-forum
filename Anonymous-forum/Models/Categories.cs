using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
