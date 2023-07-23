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
    public class InterestAssessmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestAssessmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterestAssessments
        public async Task<IActionResult> Index()
        {
              return _context.InterestAssessments != null ? 
                          View(await _context.InterestAssessments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InterestAssessments'  is null.");
        }

        // GET: InterestAssessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InterestAssessments == null)
            {
                return NotFound();
            }

            var interestAssessment = await _context.InterestAssessments
                .FirstOrDefaultAsync(m => m.InterestAssessmentId == id);
            if (interestAssessment == null)
            {
                return NotFound();
            }

            return View(interestAssessment);
        }

        // GET: InterestAssessments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterestAssessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestAssessmentId")] InterestAssessment interestAssessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interestAssessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interestAssessment);
        }

        // GET: InterestAssessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InterestAssessments == null)
            {
                return NotFound();
            }

            var interestAssessment = await _context.InterestAssessments.FindAsync(id);
            if (interestAssessment == null)
            {
                return NotFound();
            }
            return View(interestAssessment);
        }

        // POST: InterestAssessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestAssessmentId")] InterestAssessment interestAssessment)
        {
            if (id != interestAssessment.InterestAssessmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interestAssessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestAssessmentExists(interestAssessment.InterestAssessmentId))
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
            return View(interestAssessment);
        }

        // GET: InterestAssessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InterestAssessments == null)
            {
                return NotFound();
            }

            var interestAssessment = await _context.InterestAssessments
                .FirstOrDefaultAsync(m => m.InterestAssessmentId == id);
            if (interestAssessment == null)
            {
                return NotFound();
            }

            return View(interestAssessment);
        }

        // POST: InterestAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InterestAssessments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InterestAssessments'  is null.");
            }
            var interestAssessment = await _context.InterestAssessments.FindAsync(id);
            if (interestAssessment != null)
            {
                _context.InterestAssessments.Remove(interestAssessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestAssessmentExists(int id)
        {
          return (_context.InterestAssessments?.Any(e => e.InterestAssessmentId == id)).GetValueOrDefault();
        }
    }
}
