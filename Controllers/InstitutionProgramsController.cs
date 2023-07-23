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
    public class InstitutionProgramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionPrograms
        public async Task<IActionResult> Index()
        {
              return _context.InstitutionPrograms != null ? 
                          View(await _context.InstitutionPrograms.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InstitutionPrograms'  is null.");
        }

        // GET: InstitutionPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstitutionPrograms == null)
            {
                return NotFound();
            }

            var institutionProgram = await _context.InstitutionPrograms
                .FirstOrDefaultAsync(m => m.InstitutionProgramId == id);
            if (institutionProgram == null)
            {
                return NotFound();
            }

            return View(institutionProgram);
        }

        // GET: InstitutionPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionProgramId")] InstitutionProgram institutionProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionProgram);
        }

        // GET: InstitutionPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstitutionPrograms == null)
            {
                return NotFound();
            }

            var institutionProgram = await _context.InstitutionPrograms.FindAsync(id);
            if (institutionProgram == null)
            {
                return NotFound();
            }
            return View(institutionProgram);
        }

        // POST: InstitutionPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionProgramId")] InstitutionProgram institutionProgram)
        {
            if (id != institutionProgram.InstitutionProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionProgramExists(institutionProgram.InstitutionProgramId))
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
            return View(institutionProgram);
        }

        // GET: InstitutionPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstitutionPrograms == null)
            {
                return NotFound();
            }

            var institutionProgram = await _context.InstitutionPrograms
                .FirstOrDefaultAsync(m => m.InstitutionProgramId == id);
            if (institutionProgram == null)
            {
                return NotFound();
            }

            return View(institutionProgram);
        }

        // POST: InstitutionPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstitutionPrograms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InstitutionPrograms'  is null.");
            }
            var institutionProgram = await _context.InstitutionPrograms.FindAsync(id);
            if (institutionProgram != null)
            {
                _context.InstitutionPrograms.Remove(institutionProgram);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionProgramExists(int id)
        {
          return (_context.InstitutionPrograms?.Any(e => e.InstitutionProgramId == id)).GetValueOrDefault();
        }
    }
}
