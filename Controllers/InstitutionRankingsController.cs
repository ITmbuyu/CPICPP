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
    public class InstitutionRankingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionRankingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionRankings
        public async Task<IActionResult> Index()
        {
              return _context.InstitutionRanking != null ? 
                          View(await _context.InstitutionRanking.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InstitutionRanking'  is null.");
        }

        // GET: InstitutionRankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstitutionRanking == null)
            {
                return NotFound();
            }

            var institutionRanking = await _context.InstitutionRanking
                .FirstOrDefaultAsync(m => m.InstitutionRankingId == id);
            if (institutionRanking == null)
            {
                return NotFound();
            }

            return View(institutionRanking);
        }

        // GET: InstitutionRankings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionRankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionRankingId")] InstitutionRanking institutionRanking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionRanking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionRanking);
        }

        // GET: InstitutionRankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstitutionRanking == null)
            {
                return NotFound();
            }

            var institutionRanking = await _context.InstitutionRanking.FindAsync(id);
            if (institutionRanking == null)
            {
                return NotFound();
            }
            return View(institutionRanking);
        }

        // POST: InstitutionRankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionRankingId")] InstitutionRanking institutionRanking)
        {
            if (id != institutionRanking.InstitutionRankingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionRanking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionRankingExists(institutionRanking.InstitutionRankingId))
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
            return View(institutionRanking);
        }

        // GET: InstitutionRankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstitutionRanking == null)
            {
                return NotFound();
            }

            var institutionRanking = await _context.InstitutionRanking
                .FirstOrDefaultAsync(m => m.InstitutionRankingId == id);
            if (institutionRanking == null)
            {
                return NotFound();
            }

            return View(institutionRanking);
        }

        // POST: InstitutionRankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstitutionRanking == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InstitutionRanking'  is null.");
            }
            var institutionRanking = await _context.InstitutionRanking.FindAsync(id);
            if (institutionRanking != null)
            {
                _context.InstitutionRanking.Remove(institutionRanking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionRankingExists(int id)
        {
          return (_context.InstitutionRanking?.Any(e => e.InstitutionRankingId == id)).GetValueOrDefault();
        }
    }
}
