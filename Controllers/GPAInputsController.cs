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
    public class GPAInputsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GPAInputsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GPAInputs
        public async Task<IActionResult> Index()
        {
              return _context.GPAInputs != null ? 
                          View(await _context.GPAInputs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GPAInputs'  is null.");
        }

        // GET: GPAInputs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GPAInputs == null)
            {
                return NotFound();
            }

            var gPAInput = await _context.GPAInputs
                .FirstOrDefaultAsync(m => m.GPAInputId == id);
            if (gPAInput == null)
            {
                return NotFound();
            }

            return View(gPAInput);
        }

        // GET: GPAInputs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GPAInputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GPAInputId")] GPAInput gPAInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPAInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gPAInput);
        }

        // GET: GPAInputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GPAInputs == null)
            {
                return NotFound();
            }

            var gPAInput = await _context.GPAInputs.FindAsync(id);
            if (gPAInput == null)
            {
                return NotFound();
            }
            return View(gPAInput);
        }

        // POST: GPAInputs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GPAInputId")] GPAInput gPAInput)
        {
            if (id != gPAInput.GPAInputId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPAInput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPAInputExists(gPAInput.GPAInputId))
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
            return View(gPAInput);
        }

        // GET: GPAInputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GPAInputs == null)
            {
                return NotFound();
            }

            var gPAInput = await _context.GPAInputs
                .FirstOrDefaultAsync(m => m.GPAInputId == id);
            if (gPAInput == null)
            {
                return NotFound();
            }

            return View(gPAInput);
        }

        // POST: GPAInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GPAInputs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GPAInputs'  is null.");
            }
            var gPAInput = await _context.GPAInputs.FindAsync(id);
            if (gPAInput != null)
            {
                _context.GPAInputs.Remove(gPAInput);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPAInputExists(int id)
        {
          return (_context.GPAInputs?.Any(e => e.GPAInputId == id)).GetValueOrDefault();
        }
    }
}
