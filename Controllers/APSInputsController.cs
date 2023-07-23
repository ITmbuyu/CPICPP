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
    public class APSInputsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APSInputsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: APSInputs
        public async Task<IActionResult> Index()
        {
              return _context.APSInputs != null ? 
                          View(await _context.APSInputs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.APSInputs'  is null.");
        }

        // GET: APSInputs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.APSInputs == null)
            {
                return NotFound();
            }

            var aPSInput = await _context.APSInputs
                .FirstOrDefaultAsync(m => m.APSInputId == id);
            if (aPSInput == null)
            {
                return NotFound();
            }

            return View(aPSInput);
        }

        // GET: APSInputs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: APSInputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("APSInputId,HomeLan,HomeLanScore,FirstLan,FirstLanScore,OptionalLan,OptionalLanScore,Math,MathScore,LO,LOScore,AddSubject1,AddSubject1Score,AddSubject2,AddSubject2Score,AddSubject3,AddSubject3Score,AddSubject4,AddSubject4Score,AddSubject5,AddSubject5Score,TotalScore")] APSInput aPSInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aPSInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPSInput);
        }

        // GET: APSInputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.APSInputs == null)
            {
                return NotFound();
            }

            var aPSInput = await _context.APSInputs.FindAsync(id);
            if (aPSInput == null)
            {
                return NotFound();
            }
            return View(aPSInput);
        }

        // POST: APSInputs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("APSInputId,HomeLan,HomeLanScore,FirstLan,FirstLanScore,OptionalLan,OptionalLanScore,Math,MathScore,LO,LOScore,AddSubject1,AddSubject1Score,AddSubject2,AddSubject2Score,AddSubject3,AddSubject3Score,AddSubject4,AddSubject4Score,AddSubject5,AddSubject5Score,TotalScore")] APSInput aPSInput)
        {
            if (id != aPSInput.APSInputId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPSInput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!APSInputExists(aPSInput.APSInputId))
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
            return View(aPSInput);
        }

        // GET: APSInputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.APSInputs == null)
            {
                return NotFound();
            }

            var aPSInput = await _context.APSInputs
                .FirstOrDefaultAsync(m => m.APSInputId == id);
            if (aPSInput == null)
            {
                return NotFound();
            }

            return View(aPSInput);
        }

        // POST: APSInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.APSInputs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.APSInputs'  is null.");
            }
            var aPSInput = await _context.APSInputs.FindAsync(id);
            if (aPSInput != null)
            {
                _context.APSInputs.Remove(aPSInput);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool APSInputExists(int id)
        {
          return (_context.APSInputs?.Any(e => e.APSInputId == id)).GetValueOrDefault();
        }
    }
}
