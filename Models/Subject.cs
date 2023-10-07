namespace CPICPP.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? subjectcategoryid { get; set; }
        public SubjectCategory? SubjectCategory { get; set; }
    }
}