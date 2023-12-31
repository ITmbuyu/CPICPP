﻿using System;
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
    public class PostalCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostalCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostalCodes
        public async Task<IActionResult> Index()
        {
              return _context.PostalCodes != null ? 
                          View(await _context.PostalCodes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PostalCodes'  is null.");
        }

        // GET: PostalCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var postalCode = await _context.PostalCodes
                .FirstOrDefaultAsync(m => m.PostalCodeId == id);
            if (postalCode == null)
            {
                return NotFound();
            }

            return View(postalCode);
        }

        // GET: PostalCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostalCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostalCodeId")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postalCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postalCode);
        }

        // GET: PostalCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var postalCode = await _context.PostalCodes.FindAsync(id);
            if (postalCode == null)
            {
                return NotFound();
            }
            return View(postalCode);
        }

        // POST: PostalCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostalCodeId")] PostalCode postalCode)
        {
            if (id != postalCode.PostalCodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postalCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostalCodeExists(postalCode.PostalCodeId))
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
            return View(postalCode);
        }

        // GET: PostalCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var postalCode = await _context.PostalCodes
                .FirstOrDefaultAsync(m => m.PostalCodeId == id);
            if (postalCode == null)
            {
                return NotFound();
            }

            return View(postalCode);
        }

        // POST: PostalCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostalCodes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PostalCodes'  is null.");
            }
            var postalCode = await _context.PostalCodes.FindAsync(id);
            if (postalCode != null)
            {
                _context.PostalCodes.Remove(postalCode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostalCodeExists(int id)
        {
          return (_context.PostalCodes?.Any(e => e.PostalCodeId == id)).GetValueOrDefault();
        }
    }
}
