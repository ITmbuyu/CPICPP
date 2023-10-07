using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPICPP.Data;
using CPICPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPICPP.Controllers
{
    public class MBTIQ_RController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MBTIQ_RController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display the questionnaire to users
        public async Task<IActionResult> Questionnaire()
        {
            List<QuestionnaireQuestion> questions = await _context.QuestionnaireQuestions.ToListAsync();
            return View(questions);
        }

        [HttpPost]
        public IActionResult Index(Dictionary<int, bool> answers)
        {
            // Calculate MBTI points based on user responses
            int extraversionPoints = CalculatePoints(answers, "Extraversion");
            int introversionPoints = answers.Count - extraversionPoints;

            int sensingPoints = CalculatePoints(answers, "Sensing");
            int intuitionPoints = answers.Count - sensingPoints;

            int thinkingPoints = CalculatePoints(answers, "Thinking");
            int feelingPoints = answers.Count - thinkingPoints;

            int judgingPoints = CalculatePoints(answers, "Judging");
            int perceivingPoints = answers.Count - judgingPoints;

            // Determine the MBTI type
            string mbtiType = DetermineMBTIType(extraversionPoints, introversionPoints, sensingPoints, intuitionPoints, thinkingPoints, feelingPoints, judgingPoints, perceivingPoints);

            // Save user responses and MBTI type to the database (you'll need to implement this part)
            // ...

            // Pass user responses and MBTI type to the Response view
            ViewBag.MBTIType = mbtiType;
            return View("Response", answers);
        }

        // Helper method to calculate points for a specific dimension
        private int CalculatePoints(Dictionary<int, bool> answers, string dimensionPrefix)
        {
            return answers.Count(a => a.Key % 8 == 0 && a.Value);
        }

        // Helper method to determine the MBTI type
        private string DetermineMBTIType(int extraversionPoints, int introversionPoints, int sensingPoints, int intuitionPoints, int thinkingPoints, int feelingPoints, int judgingPoints, int perceivingPoints)
        {
            string eiType = extraversionPoints > introversionPoints ? "E" : "I";
            string snType = sensingPoints > intuitionPoints ? "S" : "N";
            string tfType = thinkingPoints > feelingPoints ? "T" : "F";
            string jpType = judgingPoints > perceivingPoints ? "J" : "P";
            return $"{eiType}{snType}{tfType}{jpType}";
        }


        public IActionResult Index()
        {
            return RedirectToAction("Questionnaire");
        }
    }
}
