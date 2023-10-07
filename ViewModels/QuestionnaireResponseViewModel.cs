using CPICPP.Models;

namespace CPICPP.ViewModels
{
    public class QuestionnaireResponseViewModel
    {
        public List<string> QuestionTexts { get; set; } // List to store question text
        public List<string> Dimensions { get; set; }    // List to store dimensions
        public Dictionary<int, bool> UserResponses { get; set; } // Dictionary to store user responses
    }



}
