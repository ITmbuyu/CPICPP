using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPICPP.Data;
using CPICPP.Models;
using CPICPP.ViewModels;

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
            var applicationDbContext = _context.QuestionnaireResponses.Include(q => q.QuestionnaireQuestion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuestionnaireResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionnaireResponses == null)
            {
                return NotFound();
            }

            var questionnaireResponse = await _context.QuestionnaireResponses
                .Include(q => q.QuestionnaireQuestion)
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
            // Fetch question text and dimensions from the database
            var questions = _context.QuestionnaireQuestions.ToList();

            // Create a ViewModel and populate the QuestionTexts and Dimensions properties
            var viewModel = new QuestionnaireResponseViewModel
            {
                QuestionTexts = questions.OrderBy(q => q.QuestionnaireQuestionId).Select(q => q.QuestionText).ToList(),
                Dimensions = questions.OrderBy(q => q.QuestionnaireQuestionId).Select(q => q.Dimension).ToList()
            };

            // Return the view with the ViewModel
            return View(viewModel);
        }







        // POST: QuestionnaireResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionnaireResponseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create counters for the different dimension types
                int extraversionPoints = 0;
                int introversionPoints = 0;
                int sensingPoints = 0;
                int intuitionPoints = 0;
                int thinkingPoints = 0;
                int feelingPoints = 0;
                int judgingPoints = 0;
                int perceivingPoints = 0;

                // Iterate through questions and user responses
                for (int i = 0; i < viewModel.QuestionTexts.Count; i++)
                {
                    bool response = viewModel.UserResponses[i]; // The user response (true or false)
                    string dimension = viewModel.Dimensions[i]; // The question's dimension

                    if (response) // Check if the response is "true"
                    {
                        // Increment the corresponding dimension counter based on the question's dimension
                        switch (dimension)
                        {
                            case "Extraversion":
                                extraversionPoints++;
                                break;
                            case "Introversion":
                                introversionPoints++;
                                break;
                            case "Sensing":
                                sensingPoints++;
                                break;
                            case "Intuition":
                                intuitionPoints++;
                                break;
                            case "Thinking":
                                thinkingPoints++;
                                break;
                            case "Feeling":
                                feelingPoints++;
                                break;
                            case "Judging":
                                judgingPoints++;
                                break;
                            case "Perceiving":
                                perceivingPoints++;
                                break;
                            default:
                                // Handle unexpected dimension value here
                                break;
                        }
                    }
                }

                // Determine the MBTI type based on the dimension counters
                // Initialize the MBTI type code components
                string eiType = extraversionPoints > introversionPoints ? "E" : "I";
                string snType = sensingPoints > intuitionPoints ? "S" : "N";
                string tfType = thinkingPoints > feelingPoints ? "T" : "F";
                string jpType = judgingPoints > perceivingPoints ? "J" : "P";

                // Concatenate the components to get the MBTI type
                string mbtiType = $"{eiType}{snType}{tfType}{jpType}";

                var questionnaireResponse = new QuestionnaireResponse
                {
                    MBTIType = mbtiType,
                    UserId = "testuser", // Replace with the actual user ID
                    UserResponsesJson = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel.UserResponses),
                    QuestionsAskedJson = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel.QuestionTexts)
                };
                //questionnaireResponse.MBTIType = mbtiType;
                ////questionnaireResponse.UserId = User.Identity.Name;
                //questionnaireResponse.UserId = "testuser";
                //questionnaireResponse.UserResponsesJson = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel.UserResponses);
                //questionnaireResponse.QuestionsAskedJson = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel.Questions);

                _context.Add(questionnaireResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
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
            ViewData["QuestionnaireQuestionId"] = new SelectList(_context.QuestionnaireQuestions, "QuestionnaireQuestionId", "QuestionnaireQuestionId", questionnaireResponse.QuestionnaireQuestionId);
            return View(questionnaireResponse);
        }

        // POST: QuestionnaireResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionnaireResponseId,QuestionnaireQuestionId,UserId,UserResponsesJson,QuestionsAskedJson,MBTIType")] QuestionnaireResponse questionnaireResponse)
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
            ViewData["QuestionnaireQuestionId"] = new SelectList(_context.QuestionnaireQuestions, "QuestionnaireQuestionId", "QuestionnaireQuestionId", questionnaireResponse.QuestionnaireQuestionId);
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
                .Include(q => q.QuestionnaireQuestion)
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
