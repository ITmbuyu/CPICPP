namespace CPICPP.Models
{
    public class CareerJob
    {
        public int CareerJobId { get; set; } 
        public string CareerJobName { get; set; }
        public string CareerJobDescription { get; set; }
        public int? CareerCategoryId { get; set; }
        public virtual CareerCategory? CareerCategory { get; set; }  

    }
}