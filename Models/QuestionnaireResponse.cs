namespace CPICPP.Models
{
    public class QuestionnaireResponse
    {
        public int QuestionnaireResponseId { get; set; }
        public int? QuestionnaireQuestionId { get; set; } // Make it nullable
        public string? UserId { get; set; }
        public string? UserResponsesJson { get; set; } // Make it nullable
        public string? QuestionsAskedJson { get; set; } // Make it nullable
        public string? MBTIType { get; set; } // Make it nullable
        public QuestionnaireQuestion? QuestionnaireQuestion { get; set; } // Make it nullable
    }

}