using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConestogaCarpoolApplication.Models;

namespace ConestogaCarpoolApplication.Controllers
{
    public class PostController : Controller
    {
        private readonly ConestogaCarpoolContext _context;

        public PostController(ConestogaCarpoolContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index(string Location, string Destination)
        {
            var conestogaCarpoolContext = _context.Post.Include(p => p.Driver).Include(p => p.Status).Where(p => p.Location == Location && p.Destination == Destination);

			return View(await conestogaCarpoolContext.ToListAsync());
        }

		public async Task<IActionResult> PassengerIndex(string Location, string Destination)
		{
			var conestogaCarpoolContext = _context.Post.Include(p => p.Driver).Include(p => p.Status).Where(p => p.Location == Location && p.Destination == Destination);

			return View(await conestogaCarpoolContext.ToListAsync());
		}

		public async Task<IActionResult> DriverIndex(string Location, string Destination)
		{
			var conestogaCarpoolContext = _context.Post.Include(p => p.Driver).Include(p => p.Status).Where(p => p.Location == Location && p.Destination == Destination);

			return View(await conestogaCarpoolContext.ToListAsync());
		}

		// GET: Post/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Driver)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.User, "UserId", "Email");
            ViewData["StatusId"] = new SelectList(_context.PostStatus, "PostStatusId", "Status");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,StatusId,DriverId,Destination,Location,Date,Time")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.User, "UserId", "Email", post.DriverId);
            ViewData["StatusId"] = new SelectList(_context.PostStatus, "PostStatusId", "Status", post.StatusId);
            return View(post);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.User, "UserId", "Email", post.DriverId);
            ViewData["StatusId"] = new SelectList(_context.PostStatus, "PostStatusId", "Status", post.StatusId);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,StatusId,DriverId,Destination,Location,Date,Time")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["DriverId"] = new SelectList(_context.User, "UserId", "Email", post.DriverId);
            ViewData["StatusId"] = new SelectList(_context.PostStatus, "PostStatusId", "Status", post.StatusId);
            return View(post);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Driver)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostId == id);
        }
    }
}
