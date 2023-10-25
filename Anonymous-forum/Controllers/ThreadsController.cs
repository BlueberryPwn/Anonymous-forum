using Anonymous_forum.Data;
using Anonymous_forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Anonymous_forum.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly ForumContext _dbContext;
        public ThreadsController(ForumContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var result = _dbContext.Threads.Where(x => x.CategoryId == id).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateThreads()
        {
            var result = new ThreadsViewModel
            {
                Categories = _dbContext.Categories
                .Select(c => new SelectListItem()
                {
                    Value = c.CategoryId.ToString()
                })
                .ToList()
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult CreateThreads(Threads threads)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Threads.Add(threads);
                _dbContext.SaveChanges();

                return Redirect("/");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Comments(int id)
        {
            var result = _dbContext.Comments.Where(x => x.ThreadId == id).ToList();

            return View(result);
        }

        [HttpPost]
        public IActionResult CreateComments(Comments comments)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Comments.Add(comments);
                _dbContext.SaveChanges();

                return Redirect("/");
            }
            else
            {
                return View();
            }
        }
    }
}
