using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConestogaCarpoolApplication.Models;
using Microsoft.AspNetCore.Http;

namespace ConestogaCarpoolApplication.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ConestogaCarpoolContext _context;

        public VehicleController(ConestogaCarpoolContext context)
        {
            _context = context;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index(int? UserId)
        {
            if (UserId != null)
            {
                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(UserId));
            }
            else if (UserId == null)
            {
                if (HttpContext.Session.GetInt32("UserId") != null)
                {
                    UserId = HttpContext.Session.GetInt32("UserId");
                }
            }

            ViewBag.UserId = UserId;

            var conestogaCarpoolContext = _context.Vehicle.Where(x => x.UserId == UserId);

            if (!conestogaCarpoolContext.Any())
            {
                return RedirectToAction(nameof(Create));
            }

            return View(await conestogaCarpoolContext.ToListAsync());
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Colour)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");

            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "Colour1");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,UserId,Make,Model,Year,ColourId,Plate,Image")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "Colour1", vehicle.ColourId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", vehicle.UserId);
            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "Colour1", vehicle.ColourId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", vehicle.UserId);
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,UserId,Make,Model,Year,ColourId,Plate,Image")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            ViewData["ColourId"] = new SelectList(_context.Colour, "ColourId", "Colour1", vehicle.ColourId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", vehicle.UserId);
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Colour)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleId == id);
        }
    }
}
