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
    public class SubjectCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubjectCategories
        public async Task<IActionResult> Index()
        {
              return _context.SubjectCategorys != null ? 
                          View(await _context.SubjectCategorys.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SubjectCategorys'  is null.");
        }

        // GET: SubjectCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubjectCategorys == null)
            {
                return NotFound();
            }

            var subjectCategory = await _context.SubjectCategorys
                .FirstOrDefaultAsync(m => m.SubjectCategoryId == id);
            if (subjectCategory == null)
            {
                return NotFound();
            }

            return View(subjectCategory);
        }

        // GET: SubjectCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectCategoryId,SubjectCategoryName")] SubjectCategory subjectCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectCategory);
        }

        // GET: SubjectCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubjectCategorys == null)
            {
                return NotFound();
            }

            var subjectCategory = await _context.SubjectCategorys.FindAsync(id);
            if (subjectCategory == null)
            {
                return NotFound();
            }
            return View(subjectCategory);
        }

        // POST: SubjectCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectCategoryId,SubjectCategoryName")] SubjectCategory subjectCategory)
        {
            if (id != subjectCategory.SubjectCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectCategoryExists(subjectCategory.SubjectCategoryId))
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
            return View(subjectCategory);
        }

        // GET: SubjectCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubjectCategorys == null)
            {
                return NotFound();
            }

            var subjectCategory = await _context.SubjectCategorys
                .FirstOrDefaultAsync(m => m.SubjectCategoryId == id);
            if (subjectCategory == null)
            {
                return NotFound();
            }

            return View(subjectCategory);
        }

        // POST: SubjectCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubjectCategorys == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubjectCategorys'  is null.");
            }
            var subjectCategory = await _context.SubjectCategorys.FindAsync(id);
            if (subjectCategory != null)
            {
                _context.SubjectCategorys.Remove(subjectCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectCategoryExists(int id)
        {
          return (_context.SubjectCategorys?.Any(e => e.SubjectCategoryId == id)).GetValueOrDefault();
        }
    }
}
