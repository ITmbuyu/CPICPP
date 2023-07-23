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
    public class InstitutionAlumnisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionAlumnisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionAlumnis
        public async Task<IActionResult> Index()
        {
              return _context.InstitutionAlumnis != null ? 
                          View(await _context.InstitutionAlumnis.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InstitutionAlumnis'  is null.");
        }

        // GET: InstitutionAlumnis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstitutionAlumnis == null)
            {
                return NotFound();
            }

            var institutionAlumni = await _context.InstitutionAlumnis
                .FirstOrDefaultAsync(m => m.InstitutionAlumniId == id);
            if (institutionAlumni == null)
            {
                return NotFound();
            }

            return View(institutionAlumni);
        }

        // GET: InstitutionAlumnis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionAlumnis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionAlumniId")] InstitutionAlumni institutionAlumni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionAlumni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionAlumni);
        }

        // GET: InstitutionAlumnis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstitutionAlumnis == null)
            {
                return NotFound();
            }

            var institutionAlumni = await _context.InstitutionAlumnis.FindAsync(id);
            if (institutionAlumni == null)
            {
                return NotFound();
            }
            return View(institutionAlumni);
        }

        // POST: InstitutionAlumnis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionAlumniId")] InstitutionAlumni institutionAlumni)
        {
            if (id != institutionAlumni.InstitutionAlumniId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionAlumni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionAlumniExists(institutionAlumni.InstitutionAlumniId))
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
            return View(institutionAlumni);
        }

        // GET: InstitutionAlumnis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstitutionAlumnis == null)
            {
                return NotFound();
            }

            var institutionAlumni = await _context.InstitutionAlumnis
                .FirstOrDefaultAsync(m => m.InstitutionAlumniId == id);
            if (institutionAlumni == null)
            {
                return NotFound();
            }

            return View(institutionAlumni);
        }

        // POST: InstitutionAlumnis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstitutionAlumnis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InstitutionAlumnis'  is null.");
            }
            var institutionAlumni = await _context.InstitutionAlumnis.FindAsync(id);
            if (institutionAlumni != null)
            {
                _context.InstitutionAlumnis.Remove(institutionAlumni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionAlumniExists(int id)
        {
          return (_context.InstitutionAlumnis?.Any(e => e.InstitutionAlumniId == id)).GetValueOrDefault();
        }
    }
}
