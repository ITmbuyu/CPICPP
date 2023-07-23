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
    public class InstitutionReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionReviews
        public async Task<IActionResult> Index()
        {
              return _context.InstitutionReviews != null ? 
                          View(await _context.InstitutionReviews.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InstitutionReviews'  is null.");
        }

        // GET: InstitutionReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstitutionReviews == null)
            {
                return NotFound();
            }

            var institutionReview = await _context.InstitutionReviews
                .FirstOrDefaultAsync(m => m.InstitutionReviewId == id);
            if (institutionReview == null)
            {
                return NotFound();
            }

            return View(institutionReview);
        }

        // GET: InstitutionReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionReviewId")] InstitutionReview institutionReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionReview);
        }

        // GET: InstitutionReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstitutionReviews == null)
            {
                return NotFound();
            }

            var institutionReview = await _context.InstitutionReviews.FindAsync(id);
            if (institutionReview == null)
            {
                return NotFound();
            }
            return View(institutionReview);
        }

        // POST: InstitutionReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionReviewId")] InstitutionReview institutionReview)
        {
            if (id != institutionReview.InstitutionReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionReviewExists(institutionReview.InstitutionReviewId))
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
            return View(institutionReview);
        }

        // GET: InstitutionReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstitutionReviews == null)
            {
                return NotFound();
            }

            var institutionReview = await _context.InstitutionReviews
                .FirstOrDefaultAsync(m => m.InstitutionReviewId == id);
            if (institutionReview == null)
            {
                return NotFound();
            }

            return View(institutionReview);
        }

        // POST: InstitutionReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstitutionReviews == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InstitutionReviews'  is null.");
            }
            var institutionReview = await _context.InstitutionReviews.FindAsync(id);
            if (institutionReview != null)
            {
                _context.InstitutionReviews.Remove(institutionReview);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionReviewExists(int id)
        {
          return (_context.InstitutionReviews?.Any(e => e.InstitutionReviewId == id)).GetValueOrDefault();
        }
    }
}
