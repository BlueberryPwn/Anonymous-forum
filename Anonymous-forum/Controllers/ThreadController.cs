using Anonymous_forum.Data;
using Anonymous_forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anonymous_forum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ForumContext _dbContext;
        public ThreadController(ForumContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
