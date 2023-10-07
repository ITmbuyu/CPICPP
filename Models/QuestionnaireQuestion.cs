namespace CPICPP.Models
{
    public class QuestionnaireQuestion
    {
        public int QuestionnaireQuestionId { get; set; }
        public string Dimension { get; set; }
        public string QuestionText { get; set; }

        // Navigation property for QuestionnaireResponses
        public ICollection<QuestionnaireResponse>? Responses { get; set; }

    }
}