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
    public class GPAVerificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GPAVerificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GPAVerifications
        public async Task<IActionResult> Index()
        {
              return _context.GPAVerifications != null ? 
                          View(await _context.GPAVerifications.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GPAVerifications'  is null.");
        }

        // GET: GPAVerifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GPAVerifications == null)
            {
                return NotFound();
            }

            var gPAVerification = await _context.GPAVerifications
                .FirstOrDefaultAsync(m => m.GPAVerificationId == id);
            if (gPAVerification == null)
            {
                return NotFound();
            }

            return View(gPAVerification);
        }

        // GET: GPAVerifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GPAVerifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GPAVerificationId")] GPAVerification gPAVerification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPAVerification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gPAVerification);
        }

        // GET: GPAVerifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GPAVerifications == null)
            {
                return NotFound();
            }

            var gPAVerification = await _context.GPAVerifications.FindAsync(id);
            if (gPAVerification == null)
            {
                return NotFound();
            }
            return View(gPAVerification);
        }

        // POST: GPAVerifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GPAVerificationId")] GPAVerification gPAVerification)
        {
            if (id != gPAVerification.GPAVerificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPAVerification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPAVerificationExists(gPAVerification.GPAVerificationId))
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
            return View(gPAVerification);
        }

        // GET: GPAVerifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GPAVerifications == null)
            {
                return NotFound();
            }

            var gPAVerification = await _context.GPAVerifications
                .FirstOrDefaultAsync(m => m.GPAVerificationId == id);
            if (gPAVerification == null)
            {
                return NotFound();
            }

            return View(gPAVerification);
        }

        // POST: GPAVerifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GPAVerifications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GPAVerifications'  is null.");
            }
            var gPAVerification = await _context.GPAVerifications.FindAsync(id);
            if (gPAVerification != null)
            {
                _context.GPAVerifications.Remove(gPAVerification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPAVerificationExists(int id)
        {
          return (_context.GPAVerifications?.Any(e => e.GPAVerificationId == id)).GetValueOrDefault();
        }
    }
}
