using CPICPP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CPICPP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GPAInput> GPAInputs { get; set; }
        public DbSet<APSInput> APSInputs { get; set; }
        public DbSet<GPAVerification> GPAVerifications { get; set; }
        public DbSet<APSVerification> APSVerifications { get; set; }
        public DbSet<GPAAnalysis> GPAAnalysises { get; set; }
        public DbSet<APSAnalysis> APSAnalysises { get; set; }
        public DbSet<AcademicPerformanceEvaluation> AcademicPerformanceEvaluations { get; set; }
        public DbSet<CareerPathAlignment> CareerPathAlignments { get; set; }
        public DbSet<InterestAssessment> InterestAssessments { get; set; }
        public DbSet<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public DbSet<QuestionnaireResponse> QuestionnaireResponses { get; set; }
        public DbSet<InterestEvaluation> InterestEvaluations { get; set; }
        public DbSet<InterestProfile> InterestProfiles { get; set; }
        public DbSet<InterestCareerPathAlignment> InterestCareerPathAlignments { get; set; }
        public DbSet<CareerRecommendation> CareerRecommendations { get; set; }
        public DbSet<ProgressTracking> ProgressTrackings { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionProgram> InstitutionPrograms { get; set; }
        public DbSet<InstitutionRanking> InstitutionRanking { get; set; }
        public DbSet<InstitutionReview> InstitutionReviews { get; set; }
        public DbSet<InstitutionAdmissionRequirement> InstitutionAdmissionRequirements { get; set; }
        public DbSet<InstitutionCampusResource> InstitutionCampusResources { get; set; }
        public DbSet<InstitutionAlumni> InstitutionAlumnis { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<SubjectCategory> SubjectCategorys { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<CareerJob> CareerJobs { get; set; }
    }
}