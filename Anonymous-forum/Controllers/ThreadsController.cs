using AnonymousForum.Data;
using AnonymousForum.Models;
using AnonymousForum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnonymousForum.Controllers
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
            if (!string.IsNullOrEmpty(threadText) && !string.IsNullOrEmpty(threadTitle))
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

            return Redirect($"~/Threads/Index/{categoryId}");
        }

        [HttpGet]
        public IActionResult Thread(int id)
        {
            var comments = _dbContext.Comments.Where(x => x.ThreadId == id).ToList();
            var thread = _dbContext.Threads.Where(x =>x.ThreadId == id).FirstOrDefault();
            var viewModel = new ThreadViewModel 
            {
                ThreadId = id,
                CategoryId = thread?.CategoryId ?? 0,
                Comments = comments,
                ThreadTitle = thread?.ThreadTitle,
                ThreadText = thread?.ThreadText
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateComment(int threadId)
        {
            var viewModel = new CreateCommentViewModel { ThreadId = threadId };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PostComment(int threadId, string commentText)
        {
            if (!string.IsNullOrEmpty(commentText))
            {
                var comment = new Comments
                {
                    ThreadId = threadId,
                    CommentText = commentText
                };
                _dbContext.Comments.Add(comment);
                _dbContext.SaveChanges();
            }

            return Redirect($"~/Threads/Thread/{threadId}");
        }
    }
}