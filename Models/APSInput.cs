namespace CPICPP.Models
{
    public class APSInput
    {
        public int APSInputId { get; set; }
        public string TestName { get; set; }    
        public string HomeLan { get; set; }
        public int HomeLanScore { get; set; }
        public string FirstLan { get; set; }
        public int FirstLanScore { get; set; }
        public string Math { get; set; }
        public int MathScore { get; set; }
        public string LO { get; set; }
        public int LOScore { get; set; }
        public string AddSubject1 { get; set; }
        public int AddSubject1Score { get; set; }
        public string AddSubject2 { get; set; }
        public int AddSubject2Score { get; set; }
        public string AddSubject3 { get; set; }
        public int AddSubject3Score { get; set; }
        public string AddSubject4 { get; set; }
        public int AddSubject4Score { get; set; }
        public string AddSubject5 { get; set; }
        public int AddSubject5Score { get; set; }
        public int? TotalScore { get; set; }

        // Calculate APS TotalScore based on Matric marks
        public int TotalAPSScore
        {
            get
            {
                int homeLanPoints = CalculatePoints(HomeLanScore);
                int firstLanPoints = CalculatePoints(FirstLanScore);
                int mathPoints = CalculatePoints(MathScore);
                int loPoints = CalculatePoints(LOScore);
                int coreSubjectPoints = CalculateCoreSubjectsTotalScore();

                // Sum all the points excluding LO
                return homeLanPoints + firstLanPoints + mathPoints + coreSubjectPoints;
            }
        }

        // Helper method to calculate points based on percentage
        private int CalculatePoints(int percentage)
        {
            if (percentage >= 80)
            {
                return 7;
            }
            else if (percentage >= 70)
            {
                return 6;
            }
            else if (percentage >= 60)
            {
                return 5;
            }
            else if (percentage >= 50)
            {
                return 4;
            }
            else if (percentage >= 40)
            {
                return 3;
            }
            else if (percentage >= 30)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        private int CalculateCoreSubjectsTotalScore()
    {
        int[] coreSubjectScores = new int[] { AddSubject1Score, AddSubject2Score, AddSubject3Score, AddSubject4Score, AddSubject5Score };
        int totalScore = 0;

        foreach (var score in coreSubjectScores)
        {
            totalScore += CalculatePoints(score);
        }

        return totalScore;
    }

    }
}
