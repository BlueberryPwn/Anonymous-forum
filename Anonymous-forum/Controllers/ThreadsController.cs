using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anonymous_forum.Data;
using Anonymous_forum.Models;

namespace Anonymous_forum.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly Anonymous_forumContext _context;

        public ThreadsController(Anonymous_forumContext context)
        {
            _context = context;
        }

        // GET: Threads
        public async Task<IActionResult> Index()
        {
              return _context.Threads != null ? 
                          View(await _context.Threads.ToListAsync()) :
                          Problem("Entity set 'Anonymous_forumContext.Threads'  is null.");
        }

        // GET: Threads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Threads == null)
            {
                return NotFound();
            }

            var threads = await _context.Threads
                .FirstOrDefaultAsync(m => m.ThreadId == id);
            if (threads == null)
            {
                return NotFound();
            }

            return View(threads);
        }

        // GET: Threads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Threads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThreadId,ThreadText,ThreadTitle,CategoryId")] Threads threads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(threads);
        }

        // GET: Threads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Threads == null)
            {
                return NotFound();
            }

            var threads = await _context.Threads.FindAsync(id);
            if (threads == null)
            {
                return NotFound();
            }
            return View(threads);
        }

        // POST: Threads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThreadId,ThreadText,ThreadTitle,CategoryId")] Threads threads)
        {
            if (id != threads.ThreadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreadsExists(threads.ThreadId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(threads);
        }

        // GET: Threads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Threads == null)
            {
                return NotFound();
            }

            var threads = await _context.Threads
                .FirstOrDefaultAsync(m => m.ThreadId == id);
            if (threads == null)
            {
                return NotFound();
            }

            return View(threads);
        }

        // POST: Threads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Threads == null)
            {
                return Problem("Entity set 'Anonymous_forumContext.Threads'  is null.");
            }
            var threads = await _context.Threads.FindAsync(id);
            if (threads != null)
            {
                _context.Threads.Remove(threads);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreadsExists(int id)
        {
          return (_context.Threads?.Any(e => e.ThreadId == id)).GetValueOrDefault();
        }
    }
}
