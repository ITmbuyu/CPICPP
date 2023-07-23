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
    public class APSAnalysisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APSAnalysisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: APSAnalysis
        public async Task<IActionResult> Index()
        {
              return _context.APSAnalysises != null ? 
                          View(await _context.APSAnalysises.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.APSAnalysises'  is null.");
        }

        // GET: APSAnalysis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.APSAnalysises == null)
            {
                return NotFound();
            }

            var aPSAnalysis = await _context.APSAnalysises
                .FirstOrDefaultAsync(m => m.APSAnalysisId == id);
            if (aPSAnalysis == null)
            {
                return NotFound();
            }

            return View(aPSAnalysis);
        }

        // GET: APSAnalysis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: APSAnalysis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("APSAnalysisId")] APSAnalysis aPSAnalysis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aPSAnalysis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPSAnalysis);
        }

        // GET: APSAnalysis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.APSAnalysises == null)
            {
                return NotFound();
            }

            var aPSAnalysis = await _context.APSAnalysises.FindAsync(id);
            if (aPSAnalysis == null)
            {
                return NotFound();
            }
            return View(aPSAnalysis);
        }

        // POST: APSAnalysis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("APSAnalysisId")] APSAnalysis aPSAnalysis)
        {
            if (id != aPSAnalysis.APSAnalysisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPSAnalysis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!APSAnalysisExists(aPSAnalysis.APSAnalysisId))
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
            return View(aPSAnalysis);
        }

        // GET: APSAnalysis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.APSAnalysises == null)
            {
                return NotFound();
            }

            var aPSAnalysis = await _context.APSAnalysises
                .FirstOrDefaultAsync(m => m.APSAnalysisId == id);
            if (aPSAnalysis == null)
            {
                return NotFound();
            }

            return View(aPSAnalysis);
        }

        // POST: APSAnalysis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.APSAnalysises == null)
            {
                return Problem("Entity set 'ApplicationDbContext.APSAnalysises'  is null.");
            }
            var aPSAnalysis = await _context.APSAnalysises.FindAsync(id);
            if (aPSAnalysis != null)
            {
                _context.APSAnalysises.Remove(aPSAnalysis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool APSAnalysisExists(int id)
        {
          return (_context.APSAnalysises?.Any(e => e.APSAnalysisId == id)).GetValueOrDefault();
        }
    }
}
