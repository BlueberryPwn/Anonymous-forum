using AnonymousForum.Models;

namespace AnonymousForum.ViewModels
{
    public class DisplayCategoryThreadsViewModel
    {
        public int CategoryId { get; set; }
        public List<Threads>? ThreadsList { get; set; }
    }
}
