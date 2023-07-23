using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPICPP.Models;
using CPICPP.Data;

namespace CPICPP.Controllers
{
    public class AcademicPerformanceEvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicPerformanceEvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcademicPerformanceEvaluations
        public async Task<IActionResult> Index()
        {
              return _context.AcademicPerformanceEvaluations != null ? 
                          View(await _context.AcademicPerformanceEvaluations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AcademicPerformanceEvaluations'  is null.");
        }

        // GET: AcademicPerformanceEvaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AcademicPerformanceEvaluations == null)
            {
                return NotFound();
            }

            var academicPerformanceEvaluation = await _context.AcademicPerformanceEvaluations
                .FirstOrDefaultAsync(m => m.AcademicPerformanceEvaluationId == id);
            if (academicPerformanceEvaluation == null)
            {
                return NotFound();
            }

            return View(academicPerformanceEvaluation);
        }

        // GET: AcademicPerformanceEvaluations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicPerformanceEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademicPerformanceEvaluationId")] AcademicPerformanceEvaluation academicPerformanceEvaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicPerformanceEvaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicPerformanceEvaluation);
        }

        // GET: AcademicPerformanceEvaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AcademicPerformanceEvaluations == null)
            {
                return NotFound();
            }

            var academicPerformanceEvaluation = await _context.AcademicPerformanceEvaluations.FindAsync(id);
            if (academicPerformanceEvaluation == null)
            {
                return NotFound();
            }
            return View(academicPerformanceEvaluation);
        }

        // POST: AcademicPerformanceEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademicPerformanceEvaluationId")] AcademicPerformanceEvaluation academicPerformanceEvaluation)
        {
            if (id != academicPerformanceEvaluation.AcademicPerformanceEvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicPerformanceEvaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicPerformanceEvaluationExists(academicPerformanceEvaluation.AcademicPerformanceEvaluationId))
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
            return View(academicPerformanceEvaluation);
        }

        // GET: AcademicPerformanceEvaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AcademicPerformanceEvaluations == null)
            {
                return NotFound();
            }

            var academicPerformanceEvaluation = await _context.AcademicPerformanceEvaluations
                .FirstOrDefaultAsync(m => m.AcademicPerformanceEvaluationId == id);
            if (academicPerformanceEvaluation == null)
            {
                return NotFound();
            }

            return View(academicPerformanceEvaluation);
        }

        // POST: AcademicPerformanceEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AcademicPerformanceEvaluations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AcademicPerformanceEvaluations'  is null.");
            }
            var academicPerformanceEvaluation = await _context.AcademicPerformanceEvaluations.FindAsync(id);
            if (academicPerformanceEvaluation != null)
            {
                _context.AcademicPerformanceEvaluations.Remove(academicPerformanceEvaluation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicPerformanceEvaluationExists(int id)
        {
          return (_context.AcademicPerformanceEvaluations?.Any(e => e.AcademicPerformanceEvaluationId == id)).GetValueOrDefault();
        }
    }
}
