using Anonymous_forum.Models;

namespace Anonymous_forum.ViewModels
{
    public class DisplayCategoryThreadsViewModel
    {
        public int CategoryId { get; set; }
        public List<Threads>? ThreadsList { get; set; }
    }
}
