using Anonymous_forum.Data;
using Anonymous_forum.Models;
using Anonymous_forum.ViewModels;
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
            var viewModel = new DisplayCategoryThreadsViewModel { CategoryId = id, ThreadsList = result };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateThread(int categoryId)
        {
            var viewModel = new CreateThreadViewModel { CategoryId = categoryId };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PostThread(int categoryId, string threadText, string threadTitle)
        {
            if (!string.IsNullOrEmpty(threadTitle) && !string.IsNullOrEmpty(threadText))
            {
                var thread = new Threads
                {
                    CategoryId = categoryId,
                    ThreadText = threadText,
                    ThreadTitle = threadTitle
                };
                _dbContext.Threads.Add(thread);
                _dbContext.SaveChanges();
            }

            return Redirect($"~/Thread/Index/{categoryId}");
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