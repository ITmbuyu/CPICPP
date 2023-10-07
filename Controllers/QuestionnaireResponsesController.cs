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

                // Define a list of the 8 specific questions
                List<string> specificQuestions = new List<string>
        {
            "Focus on the outer world of people and things Receive energy from interacting with people Energized by taking action; active Prefer communicating by talking (over writing) Work out ideas by talking them through Learn best through sharing/doing/discussing Have broad interests",
            "Internal focus on ideas, memories, or emotion Receive energy from reflecting on thoughts Prefer communicating in writing (over talking) Learn best by having time alone to process Prefer working in quiet environments Able to focus on one project at length Known to be reflective, quiet, private, or deep",
            "Focus on the present; what is happening now Prefer real/concrete/tangible information Attentive to details, specifics, and facts Enjoy tasks with an orderly, sequential format Like having five senses engaged while working Work at a steady pace and have stamina Known to be practical, steady, and orderly",
            "Focus on future; possibilities and potential See the big picture, connections, or patterns Remember specifics when part of a pattern Imaginative and creative Bored by routine and sequential tasks Like solving problems and developing new skills Have bursts of energy rather than stamina",
            "Examine logical consequences of decisions Objectively weigh the pros and cons Base decisions on impersonal analysis and logic Energized by problem solving and critiquing Seek standard principles to apply uniformly Look for cause/effect relationships in data Consider feelings when presented as facts",
            "Base decisions on subjective values Enjoy appreciating and supporting others Actively look for qualities to praise in others Value and create harmonious environments Honor each person as a unique individual Assess impacts of decisions on others Work best in supportive, encouraging settings",
            "Prefer to make decisions with information Make decisions as soon as possible Enjoy having closure; like things settled Plan and organize their world Like roles and expectations to be clear Enjoy getting things done/being productive Plan ahead to avoid last minute stresses",
            "Prefer to take in information and understand Keep things open-ended as long as possible Seek to experience and live life; not control it Open to new options and last-minute changes Enjoy starting projects but often never finish Able to adapt; flexible Energized by last minute pressures"
        };

                // Iterate through questions and user responses
                for (int i = 0; i < viewModel.QuestionTexts.Count; i++)
                {
                    bool response = viewModel.UserResponses[i]; // The user response (true or false)
                    string dimension = viewModel.Dimensions[i]; // The question's dimension

                    // Check if the question text is one of the 8 specific questions
                    if (specificQuestions.Contains(viewModel.QuestionTexts[i]) && response)
                    {
                        // If the user answered "yes" to a specific question, add 2 points to the corresponding counter
                        switch (specificQuestions.IndexOf(viewModel.QuestionTexts[i]))
                        {
                            case 0:
                                extraversionPoints += 2;
                                break;
                            case 1:
                                introversionPoints += 2;
                                break;
                            case 2:
                                sensingPoints += 2;
                                break;
                            case 3:
                                intuitionPoints += 2;
                                break;
                            case 4:
                                thinkingPoints += 2;
                                break;
                            case 5:
                                feelingPoints += 2;
                                break;
                            case 6:
                                judgingPoints += 2;
                                break;
                            case 7:
                                perceivingPoints += 2;
                                break;
                        }
                    }

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
