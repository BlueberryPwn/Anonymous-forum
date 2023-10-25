using Anonymous_forum.Data;
using Anonymous_forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;

namespace Anonymous_forum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ForumContext _dbContext;
        public ThreadController(ForumContext dbContext)
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
        public IActionResult CreateThread()
        {
            var result = new ThreadViewModel
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
        public IActionResult CreateThread(Threads threads)
        {
            if (!ModelState.IsValid)
            {
                return View(threads);
            }

            _dbContext.Threads.Add(threads);
            _dbContext.SaveChanges();

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Thread(int id)
        {
            var result = _dbContext.Comments.Where(x => x.ThreadId == id).ToList();

            return View(result);
        }

        [HttpPost]
        public IActionResult CreateComment(Comments comments)
        {
            if (!ModelState.IsValid)
            {
                return View(comments);
            }

            _dbContext.Comments.Add(comments);
            _dbContext.SaveChanges();

            return Redirect("/");
        }
    }
}