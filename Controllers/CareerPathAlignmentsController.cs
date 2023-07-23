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
    public class CareerPathAlignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerPathAlignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CareerPathAlignments
        public async Task<IActionResult> Index()
        {
              return _context.CareerPathAlignments != null ? 
                          View(await _context.CareerPathAlignments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CareerPathAlignments'  is null.");
        }

        // GET: CareerPathAlignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CareerPathAlignments == null)
            {
                return NotFound();
            }

            var careerPathAlignment = await _context.CareerPathAlignments
                .FirstOrDefaultAsync(m => m.CareerPathAlignmentId == id);
            if (careerPathAlignment == null)
            {
                return NotFound();
            }

            return View(careerPathAlignment);
        }

        // GET: CareerPathAlignments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareerPathAlignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareerPathAlignmentId")] CareerPathAlignment careerPathAlignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerPathAlignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerPathAlignment);
        }

        // GET: CareerPathAlignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CareerPathAlignments == null)
            {
                return NotFound();
            }

            var careerPathAlignment = await _context.CareerPathAlignments.FindAsync(id);
            if (careerPathAlignment == null)
            {
                return NotFound();
            }
            return View(careerPathAlignment);
        }

        // POST: CareerPathAlignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareerPathAlignmentId")] CareerPathAlignment careerPathAlignment)
        {
            if (id != careerPathAlignment.CareerPathAlignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerPathAlignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerPathAlignmentExists(careerPathAlignment.CareerPathAlignmentId))
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
            return View(careerPathAlignment);
        }

        // GET: CareerPathAlignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CareerPathAlignments == null)
            {
                return NotFound();
            }

            var careerPathAlignment = await _context.CareerPathAlignments
                .FirstOrDefaultAsync(m => m.CareerPathAlignmentId == id);
            if (careerPathAlignment == null)
            {
                return NotFound();
            }

            return View(careerPathAlignment);
        }

        // POST: CareerPathAlignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CareerPathAlignments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CareerPathAlignments'  is null.");
            }
            var careerPathAlignment = await _context.CareerPathAlignments.FindAsync(id);
            if (careerPathAlignment != null)
            {
                _context.CareerPathAlignments.Remove(careerPathAlignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerPathAlignmentExists(int id)
        {
          return (_context.CareerPathAlignments?.Any(e => e.CareerPathAlignmentId == id)).GetValueOrDefault();
        }
    }
}
