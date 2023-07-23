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
    public class InstitutionAdmissionRequirementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionAdmissionRequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionAdmissionRequirements
        public async Task<IActionResult> Index()
        {
              return _context.InstitutionAdmissionRequirements != null ? 
                          View(await _context.InstitutionAdmissionRequirements.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InstitutionAdmissionRequirements'  is null.");
        }

        // GET: InstitutionAdmissionRequirements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstitutionAdmissionRequirements == null)
            {
                return NotFound();
            }

            var institutionAdmissionRequirement = await _context.InstitutionAdmissionRequirements
                .FirstOrDefaultAsync(m => m.InstitutionAdmissionRequirementId == id);
            if (institutionAdmissionRequirement == null)
            {
                return NotFound();
            }

            return View(institutionAdmissionRequirement);
        }

        // GET: InstitutionAdmissionRequirements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionAdmissionRequirements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionAdmissionRequirementId")] InstitutionAdmissionRequirement institutionAdmissionRequirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionAdmissionRequirement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionAdmissionRequirement);
        }

        // GET: InstitutionAdmissionRequirements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstitutionAdmissionRequirements == null)
            {
                return NotFound();
            }

            var institutionAdmissionRequirement = await _context.InstitutionAdmissionRequirements.FindAsync(id);
            if (institutionAdmissionRequirement == null)
            {
                return NotFound();
            }
            return View(institutionAdmissionRequirement);
        }

        // POST: InstitutionAdmissionRequirements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutionAdmissionRequirementId")] InstitutionAdmissionRequirement institutionAdmissionRequirement)
        {
            if (id != institutionAdmissionRequirement.InstitutionAdmissionRequirementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionAdmissionRequirement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionAdmissionRequirementExists(institutionAdmissionRequirement.InstitutionAdmissionRequirementId))
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
            return View(institutionAdmissionRequirement);
        }

        // GET: InstitutionAdmissionRequirements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstitutionAdmissionRequirements == null)
            {
                return NotFound();
            }

            var institutionAdmissionRequirement = await _context.InstitutionAdmissionRequirements
                .FirstOrDefaultAsync(m => m.InstitutionAdmissionRequirementId == id);
            if (institutionAdmissionRequirement == null)
            {
                return NotFound();
            }

            return View(institutionAdmissionRequirement);
        }

        // POST: InstitutionAdmissionRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstitutionAdmissionRequirements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InstitutionAdmissionRequirements'  is null.");
            }
            var institutionAdmissionRequirement = await _context.InstitutionAdmissionRequirements.FindAsync(id);
            if (institutionAdmissionRequirement != null)
            {
                _context.InstitutionAdmissionRequirements.Remove(institutionAdmissionRequirement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionAdmissionRequirementExists(int id)
        {
          return (_context.InstitutionAdmissionRequirements?.Any(e => e.InstitutionAdmissionRequirementId == id)).GetValueOrDefault();
        }
    }
}
