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
    public class GPAAnalysisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GPAAnalysisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GPAAnalysis
        public async Task<IActionResult> Index()
        {
              return _context.GPAAnalysises != null ? 
                          View(await _context.GPAAnalysises.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GPAAnalysises'  is null.");
        }

        // GET: GPAAnalysis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GPAAnalysises == null)
            {
                return NotFound();
            }

            var gPAAnalysis = await _context.GPAAnalysises
                .FirstOrDefaultAsync(m => m.GPAAnalysisId == id);
            if (gPAAnalysis == null)
            {
                return NotFound();
            }

            return View(gPAAnalysis);
        }

        // GET: GPAAnalysis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GPAAnalysis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GPAAnalysisId")] GPAAnalysis gPAAnalysis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPAAnalysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gPAAnalysis);
        }

        // GET: GPAAnalysis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GPAAnalysises == null)
            {
                return NotFound();
            }

            var gPAAnalysis = await _context.GPAAnalysises.FindAsync(id);
            if (gPAAnalysis == null)
            {
                return NotFound();
            }
            return View(gPAAnalysis);
        }

        // POST: GPAAnalysis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GPAAnalysisId")] GPAAnalysis gPAAnalysis)
        {
            if (id != gPAAnalysis.GPAAnalysisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPAAnalysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPAAnalysisExists(gPAAnalysis.GPAAnalysisId))
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
            return View(gPAAnalysis);
        }

        // GET: GPAAnalysis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GPAAnalysises == null)
            {
                return NotFound();
            }

            var gPAAnalysis = await _context.GPAAnalysises
                .FirstOrDefaultAsync(m => m.GPAAnalysisId == id);
            if (gPAAnalysis == null)
            {
                return NotFound();
            }

            return View(gPAAnalysis);
        }

        // POST: GPAAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GPAAnalysises == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GPAAnalysises'  is null.");
            }
            var gPAAnalysis = await _context.GPAAnalysises.FindAsync(id);
            if (gPAAnalysis != null)
            {
                _context.GPAAnalysises.Remove(gPAAnalysis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPAAnalysisExists(int id)
        {
          return (_context.GPAAnalysises?.Any(e => e.GPAAnalysisId == id)).GetValueOrDefault();
        }
    }
}
