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
    public class QuestionnaireQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionnaireQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionnaireQuestions
        public async Task<IActionResult> Index()
        {
              return _context.QuestionnaireQuestions != null ? 
                          View(await _context.QuestionnaireQuestions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuestionnaireQuestions'  is null.");
        }

        // GET: QuestionnaireQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionnaireQuestions == null)
            {
                return NotFound();
            }

            var questionnaireQuestion = await _context.QuestionnaireQuestions
                .FirstOrDefaultAsync(m => m.QuestionnaireQuestionId == id);
            if (questionnaireQuestion == null)
            {
                return NotFound();
            }

            return View(questionnaireQuestion);
        }

        // GET: QuestionnaireQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionnaireQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionnaireQuestionId")] QuestionnaireQuestion questionnaireQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionnaireQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionnaireQuestion);
        }

        // GET: QuestionnaireQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestionnaireQuestions == null)
            {
                return NotFound();
            }

            var questionnaireQuestion = await _context.QuestionnaireQuestions.FindAsync(id);
            if (questionnaireQuestion == null)
            {
                return NotFound();
            }
            return View(questionnaireQuestion);
        }

        // POST: QuestionnaireQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionnaireQuestionId")] QuestionnaireQuestion questionnaireQuestion)
        {
            if (id != questionnaireQuestion.QuestionnaireQuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionnaireQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionnaireQuestionExists(questionnaireQuestion.QuestionnaireQuestionId))
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
            return View(questionnaireQuestion);
        }

        // GET: QuestionnaireQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestionnaireQuestions == null)
            {
                return NotFound();
            }

            var questionnaireQuestion = await _context.QuestionnaireQuestions
                .FirstOrDefaultAsync(m => m.QuestionnaireQuestionId == id);
            if (questionnaireQuestion == null)
            {
                return NotFound();
            }

            return View(questionnaireQuestion);
        }

        // POST: QuestionnaireQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestionnaireQuestions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuestionnaireQuestions'  is null.");
            }
            var questionnaireQuestion = await _context.QuestionnaireQuestions.FindAsync(id);
            if (questionnaireQuestion != null)
            {
                _context.QuestionnaireQuestions.Remove(questionnaireQuestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionnaireQuestionExists(int id)
        {
          return (_context.QuestionnaireQuestions?.Any(e => e.QuestionnaireQuestionId == id)).GetValueOrDefault();
        }
    }
}
