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
    public class InterestCareerPathAlignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestCareerPathAlignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterestCareerPathAlignments
        public async Task<IActionResult> Index()
        {
              return _context.InterestCareerPathAlignments != null ? 
                          View(await _context.InterestCareerPathAlignments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InterestCareerPathAlignments'  is null.");
        }

        // GET: InterestCareerPathAlignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InterestCareerPathAlignments == null)
            {
                return NotFound();
            }

            var interestCareerPathAlignment = await _context.InterestCareerPathAlignments
                .FirstOrDefaultAsync(m => m.InterestCareerPathAlignmentId == id);
            if (interestCareerPathAlignment == null)
            {
                return NotFound();
            }

            return View(interestCareerPathAlignment);
        }

        // GET: InterestCareerPathAlignments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterestCareerPathAlignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestCareerPathAlignmentId")] InterestCareerPathAlignment interestCareerPathAlignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interestCareerPathAlignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interestCareerPathAlignment);
        }

        // GET: InterestCareerPathAlignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InterestCareerPathAlignments == null)
            {
                return NotFound();
            }

            var interestCareerPathAlignment = await _context.InterestCareerPathAlignments.FindAsync(id);
            if (interestCareerPathAlignment == null)
            {
                return NotFound();
            }
            return View(interestCareerPathAlignment);
        }

        // POST: InterestCareerPathAlignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestCareerPathAlignmentId")] InterestCareerPathAlignment interestCareerPathAlignment)
        {
            if (id != interestCareerPathAlignment.InterestCareerPathAlignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interestCareerPathAlignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestCareerPathAlignmentExists(interestCareerPathAlignment.InterestCareerPathAlignmentId))
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
            return View(interestCareerPathAlignment);
        }

        // GET: InterestCareerPathAlignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InterestCareerPathAlignments == null)
            {
                return NotFound();
            }

            var interestCareerPathAlignment = await _context.InterestCareerPathAlignments
                .FirstOrDefaultAsync(m => m.InterestCareerPathAlignmentId == id);
            if (interestCareerPathAlignment == null)
            {
                return NotFound();
            }

            return View(interestCareerPathAlignment);
        }

        // POST: InterestCareerPathAlignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InterestCareerPathAlignments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InterestCareerPathAlignments'  is null.");
            }
            var interestCareerPathAlignment = await _context.InterestCareerPathAlignments.FindAsync(id);
            if (interestCareerPathAlignment != null)
            {
                _context.InterestCareerPathAlignments.Remove(interestCareerPathAlignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestCareerPathAlignmentExists(int id)
        {
          return (_context.InterestCareerPathAlignments?.Any(e => e.InterestCareerPathAlignmentId == id)).GetValueOrDefault();
        }
    }
}
