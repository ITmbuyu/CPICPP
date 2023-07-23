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
    public class CareerJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CareerJobs
        public async Task<IActionResult> Index()
        {
              return _context.CareerJobs != null ? 
                          View(await _context.CareerJobs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CareerJobs'  is null.");
        }

        // GET: CareerJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CareerJobs == null)
            {
                return NotFound();
            }

            var careerJob = await _context.CareerJobs
                .FirstOrDefaultAsync(m => m.CareerJobId == id);
            if (careerJob == null)
            {
                return NotFound();
            }

            return View(careerJob);
        }

        // GET: CareerJobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareerJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareerJobId")] CareerJob careerJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerJob);
        }

        // GET: CareerJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CareerJobs == null)
            {
                return NotFound();
            }

            var careerJob = await _context.CareerJobs.FindAsync(id);
            if (careerJob == null)
            {
                return NotFound();
            }
            return View(careerJob);
        }

        // POST: CareerJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareerJobId")] CareerJob careerJob)
        {
            if (id != careerJob.CareerJobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerJobExists(careerJob.CareerJobId))
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
            return View(careerJob);
        }

        // GET: CareerJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CareerJobs == null)
            {
                return NotFound();
            }

            var careerJob = await _context.CareerJobs
                .FirstOrDefaultAsync(m => m.CareerJobId == id);
            if (careerJob == null)
            {
                return NotFound();
            }

            return View(careerJob);
        }

        // POST: CareerJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CareerJobs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CareerJobs'  is null.");
            }
            var careerJob = await _context.CareerJobs.FindAsync(id);
            if (careerJob != null)
            {
                _context.CareerJobs.Remove(careerJob);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerJobExists(int id)
        {
          return (_context.CareerJobs?.Any(e => e.CareerJobId == id)).GetValueOrDefault();
        }
    }
}
