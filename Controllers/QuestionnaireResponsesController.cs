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
    public class QuestionnaireResponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionnaireResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionnaireResponses
        public async Task<IActionResult> Index()
        {
              return _context.QuestionnaireResponses != null ? 
                          View(await _context.QuestionnaireResponses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuestionnaireResponses'  is null.");
        }

        // GET: QuestionnaireResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionnaireResponses == null)
            {
                return NotFound();
            }

            var questionnaireResponse = await _context.QuestionnaireResponses
                .FirstOrDefaultAsync(m => m.QuestionnaireResponseId == id);
            if (questionnaireResponse == null)
            {
                return NotFound();
            }

            return View(questionnaireResponse);
        }

        // GET: QuestionnaireResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionnaireResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionnaireResponseId")] QuestionnaireResponse questionnaireResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionnaireResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionnaireResponse);
        }

        // GET: QuestionnaireResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestionnaireResponses == null)
            {
                return NotFound();
            }

            var questionnaireResponse = await _context.QuestionnaireResponses.FindAsync(id);
            if (questionnaireResponse == null)
            {
                return NotFound();
            }
            return View(questionnaireResponse);
        }

        // POST: QuestionnaireResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionnaireResponseId")] QuestionnaireResponse questionnaireResponse)
        {
            if (id != questionnaireResponse.QuestionnaireResponseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionnaireResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionnaireResponseExists(questionnaireResponse.QuestionnaireResponseId))
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
            return View(questionnaireResponse);
        }

        // GET: QuestionnaireResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestionnaireResponses == null)
            {
                return NotFound();
            }

            var questionnaireResponse = await _context.QuestionnaireResponses
                .FirstOrDefaultAsync(m => m.QuestionnaireResponseId == id);
            if (questionnaireResponse == null)
            {
                return NotFound();
            }

            return View(questionnaireResponse);
        }

        // POST: QuestionnaireResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestionnaireResponses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuestionnaireResponses'  is null.");
            }
            var questionnaireResponse = await _context.QuestionnaireResponses.FindAsync(id);
            if (questionnaireResponse != null)
            {
                _context.QuestionnaireResponses.Remove(questionnaireResponse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionnaireResponseExists(int id)
        {
          return (_context.QuestionnaireResponses?.Any(e => e.QuestionnaireResponseId == id)).GetValueOrDefault();
        }
    }
}
