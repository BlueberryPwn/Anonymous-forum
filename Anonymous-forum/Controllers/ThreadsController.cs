using Anonymous_forum.Data;
using Anonymous_forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anonymous_forum.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly ForumContext _dbContext;
        public ThreadsController(ForumContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var result = _dbContext.Threads.Where(x => x.CategoryId == id).ToList();

            return View(result);
        }
    }
}
