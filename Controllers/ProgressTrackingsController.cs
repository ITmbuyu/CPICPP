using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPICPP.Data;
using CPICPP.Models;

namespace CPICPP.Controllers
{
    public class ProgressTrackingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgressTrackingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgressTrackings
        public async Task<IActionResult> Index()
        {
              return _context.ProgressTrackings != null ? 
                          View(await _context.ProgressTrackings.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProgressTrackings'  is null.");
        }

        // GET: ProgressTrackings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgressTrackings == null)
            {
                return NotFound();
            }

            var progressTracking = await _context.ProgressTrackings
                .FirstOrDefaultAsync(m => m.ProgressTrackingId == id);
            if (progressTracking == null)
            {
                return NotFound();
            }

            return View(progressTracking);
        }

        // GET: ProgressTrackings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgressTrackings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgressTrackingId")] ProgressTracking progressTracking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(progressTracking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(progressTracking);
        }

        // GET: ProgressTrackings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgressTrackings == null)
            {
                return NotFound();
            }

            var progressTracking = await _context.ProgressTrackings.FindAsync(id);
            if (progressTracking == null)
            {
                return NotFound();
            }
            return View(progressTracking);
        }

        // POST: ProgressTrackings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgressTrackingId")] ProgressTracking progressTracking)
        {
            if (id != progressTracking.ProgressTrackingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progressTracking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgressTrackingExists(progressTracking.ProgressTrackingId))
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
            return View(progressTracking);
        }

        // GET: ProgressTrackings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgressTrackings == null)
            {
                return NotFound();
            }

            var progressTracking = await _context.ProgressTrackings
                .FirstOrDefaultAsync(m => m.ProgressTrackingId == id);
            if (progressTracking == null)
            {
                return NotFound();
            }

            return View(progressTracking);
        }

        // POST: ProgressTrackings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgressTrackings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProgressTrackings'  is null.");
            }
            var progressTracking = await _context.ProgressTrackings.FindAsync(id);
            if (progressTracking != null)
            {
                _context.ProgressTrackings.Remove(progressTracking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgressTrackingExists(int id)
        {
          return (_context.ProgressTrackings?.Any(e => e.ProgressTrackingId == id)).GetValueOrDefault();
        }
    }
}
