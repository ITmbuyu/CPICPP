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
    public class InstitutionCampusResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionCampusResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionCampusResources
        public async Task<IActionResult> Index()
        {
              return _context.InstitutionCampusResources != null ? 
                          View(await _context.InstitutionCampusResources.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InstitutionCampusResources'  is null.");
        }

        // GET: InstitutionCampusResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstitutionCampusResources == null)
            {
                return NotFound();
            }

            var institutionCampusResource = await _context.InstitutionCampusResources
                .FirstOrDefaultAsync(m => m.InstitutionCampusResourceId == id);
            if (institutionCampusResource == null)
            {
                return NotFound();
            }

            return View(institutionCampusResource);
        }

        // GET: InstitutionCampusResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionCampusResources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionCampusResourceId")] InstitutionCampusResource institutionCampusResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionCampusResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionCampusResource);
        }

        // GET: InstitutionCampusResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstitutionCampusResources == null)
            {
                return NotFound();
            }

            var institutionCampusResource = await _context.InstitutionCampusResources.FindAsync(id);
            if (institutionCampusResource == null)
            {
                return NotFound();
            }
            return View(institutionCampusResource);
        }

        // POST: InstitutionCampusResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionCampusResourceId")] InstitutionCampusResource institutionCampusResource)
        {
            if (id != institutionCampusResource.InstitutionCampusResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionCampusResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionCampusResourceExists(institutionCampusResource.InstitutionCampusResourceId))
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
            return View(institutionCampusResource);
        }

        // GET: InstitutionCampusResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstitutionCampusResources == null)
            {
                return NotFound();
            }

            var institutionCampusResource = await _context.InstitutionCampusResources
                .FirstOrDefaultAsync(m => m.InstitutionCampusResourceId == id);
            if (institutionCampusResource == null)
            {
                return NotFound();
            }

            return View(institutionCampusResource);
        }

        // POST: InstitutionCampusResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstitutionCampusResources == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InstitutionCampusResources'  is null.");
            }
            var institutionCampusResource = await _context.InstitutionCampusResources.FindAsync(id);
            if (institutionCampusResource != null)
            {
                _context.InstitutionCampusResources.Remove(institutionCampusResource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionCampusResourceExists(int id)
        {
          return (_context.InstitutionCampusResources?.Any(e => e.InstitutionCampusResourceId == id)).GetValueOrDefault();
        }
    }
}
