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
    public class APSVerificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APSVerificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: APSVerifications
        public async Task<IActionResult> Index()
        {
              return _context.APSVerifications != null ? 
                          View(await _context.APSVerifications.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.APSVerifications'  is null.");
        }

        // GET: APSVerifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.APSVerifications == null)
            {
                return NotFound();
            }

            var aPSVerification = await _context.APSVerifications
                .FirstOrDefaultAsync(m => m.APSVerificationId == id);
            if (aPSVerification == null)
            {
                return NotFound();
            }

            return View(aPSVerification);
        }

        // GET: APSVerifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: APSVerifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("APSVerificationId")] APSVerification aPSVerification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aPSVerification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPSVerification);
        }

        // GET: APSVerifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.APSVerifications == null)
            {
                return NotFound();
            }

            var aPSVerification = await _context.APSVerifications.FindAsync(id);
            if (aPSVerification == null)
            {
                return NotFound();
            }
            return View(aPSVerification);
        }

        // POST: APSVerifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("APSVerificationId")] APSVerification aPSVerification)
        {
            if (id != aPSVerification.APSVerificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPSVerification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!APSVerificationExists(aPSVerification.APSVerificationId))
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
            return View(aPSVerification);
        }

        // GET: APSVerifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.APSVerifications == null)
            {
                return NotFound();
            }

            var aPSVerification = await _context.APSVerifications
                .FirstOrDefaultAsync(m => m.APSVerificationId == id);
            if (aPSVerification == null)
            {
                return NotFound();
            }

            return View(aPSVerification);
        }

        // POST: APSVerifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.APSVerifications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.APSVerifications'  is null.");
            }
            var aPSVerification = await _context.APSVerifications.FindAsync(id);
            if (aPSVerification != null)
            {
                _context.APSVerifications.Remove(aPSVerification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool APSVerificationExists(int id)
        {
          return (_context.APSVerifications?.Any(e => e.APSVerificationId == id)).GetValueOrDefault();
        }
    }
}
