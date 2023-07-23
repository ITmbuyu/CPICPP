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
    public class InterestEvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestEvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterestEvaluations
        public async Task<IActionResult> Index()
        {
              return _context.InterestEvaluations != null ? 
                          View(await _context.InterestEvaluations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InterestEvaluations'  is null.");
        }

        // GET: InterestEvaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InterestEvaluations == null)
            {
                return NotFound();
            }

            var interestEvaluation = await _context.InterestEvaluations
                .FirstOrDefaultAsync(m => m.InterestEvaluationId == id);
            if (interestEvaluation == null)
            {
                return NotFound();
            }

            return View(interestEvaluation);
        }

        // GET: InterestEvaluations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterestEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestEvaluationId")] InterestEvaluation interestEvaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interestEvaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interestEvaluation);
        }

        // GET: InterestEvaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InterestEvaluations == null)
            {
                return NotFound();
            }

            var interestEvaluation = await _context.InterestEvaluations.FindAsync(id);
            if (interestEvaluation == null)
            {
                return NotFound();
            }
            return View(interestEvaluation);
        }

        // POST: InterestEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestEvaluationId")] InterestEvaluation interestEvaluation)
        {
            if (id != interestEvaluation.InterestEvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interestEvaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestEvaluationExists(interestEvaluation.InterestEvaluationId))
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
            return View(interestEvaluation);
        }

        // GET: InterestEvaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InterestEvaluations == null)
            {
                return NotFound();
            }

            var interestEvaluation = await _context.InterestEvaluations
                .FirstOrDefaultAsync(m => m.InterestEvaluationId == id);
            if (interestEvaluation == null)
            {
                return NotFound();
            }

            return View(interestEvaluation);
        }

        // POST: InterestEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InterestEvaluations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InterestEvaluations'  is null.");
            }
            var interestEvaluation = await _context.InterestEvaluations.FindAsync(id);
            if (interestEvaluation != null)
            {
                _context.InterestEvaluations.Remove(interestEvaluation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestEvaluationExists(int id)
        {
          return (_context.InterestEvaluations?.Any(e => e.InterestEvaluationId == id)).GetValueOrDefault();
        }
    }
}
