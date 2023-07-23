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
    public class InterestProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterestProfiles
        public async Task<IActionResult> Index()
        {
              return _context.InterestProfiles != null ? 
                          View(await _context.InterestProfiles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InterestProfiles'  is null.");
        }

        // GET: InterestProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InterestProfiles == null)
            {
                return NotFound();
            }

            var interestProfile = await _context.InterestProfiles
                .FirstOrDefaultAsync(m => m.InterestProfileId == id);
            if (interestProfile == null)
            {
                return NotFound();
            }

            return View(interestProfile);
        }

        // GET: InterestProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterestProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestProfileId")] InterestProfile interestProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interestProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interestProfile);
        }

        // GET: InterestProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InterestProfiles == null)
            {
                return NotFound();
            }

            var interestProfile = await _context.InterestProfiles.FindAsync(id);
            if (interestProfile == null)
            {
                return NotFound();
            }
            return View(interestProfile);
        }

        // POST: InterestProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestProfileId")] InterestProfile interestProfile)
        {
            if (id != interestProfile.InterestProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interestProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestProfileExists(interestProfile.InterestProfileId))
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
            return View(interestProfile);
        }

        // GET: InterestProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InterestProfiles == null)
            {
                return NotFound();
            }

            var interestProfile = await _context.InterestProfiles
                .FirstOrDefaultAsync(m => m.InterestProfileId == id);
            if (interestProfile == null)
            {
                return NotFound();
            }

            return View(interestProfile);
        }

        // POST: InterestProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InterestProfiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InterestProfiles'  is null.");
            }
            var interestProfile = await _context.InterestProfiles.FindAsync(id);
            if (interestProfile != null)
            {
                _context.InterestProfiles.Remove(interestProfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestProfileExists(int id)
        {
          return (_context.InterestProfiles?.Any(e => e.InterestProfileId == id)).GetValueOrDefault();
        }
    }
}
