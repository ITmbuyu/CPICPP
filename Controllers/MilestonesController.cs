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
    public class MilestonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilestonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Milestones
        public async Task<IActionResult> Index()
        {
              return _context.Milestones != null ? 
                          View(await _context.Milestones.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Milestones'  is null.");
        }

        // GET: Milestones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Milestones == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones
                .FirstOrDefaultAsync(m => m.MilestoneId == id);
            if (milestone == null)
            {
                return NotFound();
            }

            return View(milestone);
        }

        // GET: Milestones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Milestones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilestoneId")] Milestone milestone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(milestone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(milestone);
        }

        // GET: Milestones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Milestones == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones.FindAsync(id);
            if (milestone == null)
            {
                return NotFound();
            }
            return View(milestone);
        }

        // POST: Milestones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MilestoneId")] Milestone milestone)
        {
            if (id != milestone.MilestoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milestone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilestoneExists(milestone.MilestoneId))
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
            return View(milestone);
        }

        // GET: Milestones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Milestones == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones
                .FirstOrDefaultAsync(m => m.MilestoneId == id);
            if (milestone == null)
            {
                return NotFound();
            }

            return View(milestone);
        }

        // POST: Milestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Milestones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Milestones'  is null.");
            }
            var milestone = await _context.Milestones.FindAsync(id);
            if (milestone != null)
            {
                _context.Milestones.Remove(milestone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilestoneExists(int id)
        {
          return (_context.Milestones?.Any(e => e.MilestoneId == id)).GetValueOrDefault();
        }
    }
}
