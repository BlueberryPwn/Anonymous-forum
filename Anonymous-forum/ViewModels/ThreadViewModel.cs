using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Anonymous_forum.Models
{
    public class ThreadViewModel
    {
        public int ThreadId { get; set; }
        public string? ThreadText { get; set; }
        public string? ThreadTitle { get; set; }
        public int CategoryId { get; set; }
        public List<Comments>? Comments {  get; set; }
    }
}