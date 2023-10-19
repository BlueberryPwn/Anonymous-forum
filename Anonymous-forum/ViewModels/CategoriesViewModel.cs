using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.ViewModels
{
    public class CategoriesViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
