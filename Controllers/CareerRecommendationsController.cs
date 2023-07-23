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
    public class CareerRecommendationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerRecommendationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CareerRecommendations
        public async Task<IActionResult> Index()
        {
              return _context.CareerRecommendations != null ? 
                          View(await _context.CareerRecommendations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CareerRecommendations'  is null.");
        }

        // GET: CareerRecommendations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CareerRecommendations == null)
            {
                return NotFound();
            }

            var careerRecommendation = await _context.CareerRecommendations
                .FirstOrDefaultAsync(m => m.CareerRecommendationId == id);
            if (careerRecommendation == null)
            {
                return NotFound();
            }

            return View(careerRecommendation);
        }

        // GET: CareerRecommendations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareerRecommendations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareerRecommendationId")] CareerRecommendation careerRecommendation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerRecommendation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerRecommendation);
        }

        // GET: CareerRecommendations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CareerRecommendations == null)
            {
                return NotFound();
            }

            var careerRecommendation = await _context.CareerRecommendations.FindAsync(id);
            if (careerRecommendation == null)
            {
                return NotFound();
            }
            return View(careerRecommendation);
        }

        // POST: CareerRecommendations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareerRecommendationId")] CareerRecommendation careerRecommendation)
        {
            if (id != careerRecommendation.CareerRecommendationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerRecommendation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerRecommendationExists(careerRecommendation.CareerRecommendationId))
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
            return View(careerRecommendation);
        }

        // GET: CareerRecommendations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CareerRecommendations == null)
            {
                return NotFound();
            }

            var careerRecommendation = await _context.CareerRecommendations
                .FirstOrDefaultAsync(m => m.CareerRecommendationId == id);
            if (careerRecommendation == null)
            {
                return NotFound();
            }

            return View(careerRecommendation);
        }

        // POST: CareerRecommendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CareerRecommendations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CareerRecommendations'  is null.");
            }
            var careerRecommendation = await _context.CareerRecommendations.FindAsync(id);
            if (careerRecommendation != null)
            {
                _context.CareerRecommendations.Remove(careerRecommendation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerRecommendationExists(int id)
        {
          return (_context.CareerRecommendations?.Any(e => e.CareerRecommendationId == id)).GetValueOrDefault();
        }
    }
}
