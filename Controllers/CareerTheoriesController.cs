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
    public class CareerTheoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerTheoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CareerTheories
        public async Task<IActionResult> Index()
        {
              return _context.CareerTheorys != null ? 
                          View(await _context.CareerTheorys.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CareerTheorys'  is null.");
        }

        // GET: CareerTheories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CareerTheorys == null)
            {
                return NotFound();
            }

            var careerTheory = await _context.CareerTheorys
                .FirstOrDefaultAsync(m => m.CareerTheoryId == id);
            if (careerTheory == null)
            {
                return NotFound();
            }

            return View(careerTheory);
        }

        // GET: CareerTheories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareerTheories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareerTheoryId")] CareerTheory careerTheory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerTheory);
        }

        // GET: CareerTheories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CareerTheorys == null)
            {
                return NotFound();
            }

            var careerTheory = await _context.CareerTheorys.FindAsync(id);
            if (careerTheory == null)
            {
                return NotFound();
            }
            return View(careerTheory);
        }

        // POST: CareerTheories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareerTheoryId")] CareerTheory careerTheory)
        {
            if (id != careerTheory.CareerTheoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerTheory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerTheoryExists(careerTheory.CareerTheoryId))
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
            return View(careerTheory);
        }

        // GET: CareerTheories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CareerTheorys == null)
            {
                return NotFound();
            }

            var careerTheory = await _context.CareerTheorys
                .FirstOrDefaultAsync(m => m.CareerTheoryId == id);
            if (careerTheory == null)
            {
                return NotFound();
            }

            return View(careerTheory);
        }

        // POST: CareerTheories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CareerTheorys == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CareerTheorys'  is null.");
            }
            var careerTheory = await _context.CareerTheorys.FindAsync(id);
            if (careerTheory != null)
            {
                _context.CareerTheorys.Remove(careerTheory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerTheoryExists(int id)
        {
          return (_context.CareerTheorys?.Any(e => e.CareerTheoryId == id)).GetValueOrDefault();
        }
    }
}
