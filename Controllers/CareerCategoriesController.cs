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
    public class CareerCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CareerCategories
        public async Task<IActionResult> Index()
        {
              return _context.CareerCategory != null ? 
                          View(await _context.CareerCategory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CareerCategory'  is null.");
        }

        // GET: CareerCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CareerCategory == null)
            {
                return NotFound();
            }

            var careerCategory = await _context.CareerCategory
                .FirstOrDefaultAsync(m => m.CareerCategoryId == id);
            if (careerCategory == null)
            {
                return NotFound();
            }

            return View(careerCategory);
        }

        // GET: CareerCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareerCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareerCategoryId,CareerCategoryName")] CareerCategory careerCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerCategory);
        }

        // GET: CareerCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CareerCategory == null)
            {
                return NotFound();
            }

            var careerCategory = await _context.CareerCategory.FindAsync(id);
            if (careerCategory == null)
            {
                return NotFound();
            }
            return View(careerCategory);
        }

        // POST: CareerCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareerCategoryId,CareerCategoryName")] CareerCategory careerCategory)
        {
            if (id != careerCategory.CareerCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerCategoryExists(careerCategory.CareerCategoryId))
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
            return View(careerCategory);
        }

        // GET: CareerCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CareerCategory == null)
            {
                return NotFound();
            }

            var careerCategory = await _context.CareerCategory
                .FirstOrDefaultAsync(m => m.CareerCategoryId == id);
            if (careerCategory == null)
            {
                return NotFound();
            }

            return View(careerCategory);
        }

        // POST: CareerCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CareerCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CareerCategory'  is null.");
            }
            var careerCategory = await _context.CareerCategory.FindAsync(id);
            if (careerCategory != null)
            {
                _context.CareerCategory.Remove(careerCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerCategoryExists(int id)
        {
          return (_context.CareerCategory?.Any(e => e.CareerCategoryId == id)).GetValueOrDefault();
        }
    }
}
