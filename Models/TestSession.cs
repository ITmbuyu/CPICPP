namespace CPICPP.Models
{
    public class TestSession
    {
        public int TestSessionId { get; set; }
        public string? UserId { get; set; }
        public string UserResponsesJson { get; set; } // Store user responses as JSON
        public string QuestionsAskedJson { get; set; } // Store questions asked as JSON
        public string GeneratedMBTIType { get; set; }
        public int Score { get; set; }
        public string TestName { get; set; }
    }
}
