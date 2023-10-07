﻿// <auto-generated />
using System;
using CPICPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CPICPP.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231003143446_json")]
    partial class json
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CPICPP.Models.APSAnalysis", b =>
                {
                    b.Property<int>("APSAnalysisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("APSAnalysisId"));

                    b.HasKey("APSAnalysisId");

                    b.ToTable("APSAnalysises");
                });

            modelBuilder.Entity("CPICPP.Models.APSInput", b =>
                {
                    b.Property<int>("APSInputId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("APSInputId"));

                    b.Property<string>("AddSubject1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddSubject1Score")
                        .HasColumnType("int");

                    b.Property<string>("AddSubject2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddSubject2Score")
                        .HasColumnType("int");

                    b.Property<string>("AddSubject3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddSubject3Score")
                        .HasColumnType("int");

                    b.Property<string>("AddSubject4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddSubject4Score")
                        .HasColumnType("int");

                    b.Property<string>("AddSubject5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddSubject5Score")
                        .HasColumnType("int");

                    b.Property<string>("FirstLan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirstLanScore")
                        .HasColumnType("int");

                    b.Property<string>("HomeLan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeLanScore")
                        .HasColumnType("int");

                    b.Property<string>("LO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LOScore")
                        .HasColumnType("int");

                    b.Property<string>("Math")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MathScore")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("APSInputId");

                    b.ToTable("APSInputs");
                });

            modelBuilder.Entity("CPICPP.Models.APSVerification", b =>
                {
                    b.Property<int>("APSVerificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("APSVerificationId"));

                    b.HasKey("APSVerificationId");

                    b.ToTable("APSVerifications");
                });

            modelBuilder.Entity("CPICPP.Models.AcademicPerformanceEvaluation", b =>
                {
                    b.Property<int>("AcademicPerformanceEvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicPerformanceEvaluationId"));

                    b.HasKey("AcademicPerformanceEvaluationId");

                    b.ToTable("AcademicPerformanceEvaluations");
                });

            modelBuilder.Entity("CPICPP.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CPICPP.Models.CareerCategory", b =>
                {
                    b.Property<int>("CareerCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareerCategoryId"));

                    b.Property<string>("CareerCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("careercode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("careertypecode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareerCategoryId");

                    b.ToTable("CareerCategory");
                });

            modelBuilder.Entity("CPICPP.Models.CareerJob", b =>
                {
                    b.Property<int>("CareerJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareerJobId"));

                    b.Property<int?>("CareerCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CareerJobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CareerJobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareerJobId");

                    b.HasIndex("CareerCategoryId");

                    b.ToTable("CareerJobs");
                });

            modelBuilder.Entity("CPICPP.Models.CareerPathAlignment", b =>
                {
                    b.Property<int>("CareerPathAlignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareerPathAlignmentId"));

                    b.HasKey("CareerPathAlignmentId");

                    b.ToTable("CareerPathAlignments");
                });

            modelBuilder.Entity("CPICPP.Models.CareerRecommendation", b =>
                {
                    b.Property<int>("CareerRecommendationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareerRecommendationId"));

                    b.HasKey("CareerRecommendationId");

                    b.ToTable("CareerRecommendations");
                });

            modelBuilder.Entity("CPICPP.Models.CareerTheory", b =>
                {
                    b.Property<int>("CareerTheoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareerTheoryId"));

                    b.Property<string>("CareerTheoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CareerTheoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareerTheoryId");

                    b.ToTable("CareerTheorys");
                });

            modelBuilder.Entity("CPICPP.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Citys");
                });

            modelBuilder.Entity("CPICPP.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countrys");
                });

            modelBuilder.Entity("CPICPP.Models.GPAAnalysis", b =>
                {
                    b.Property<int>("GPAAnalysisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GPAAnalysisId"));

                    b.HasKey("GPAAnalysisId");

                    b.ToTable("GPAAnalysises");
                });

            modelBuilder.Entity("CPICPP.Models.GPAInput", b =>
                {
                    b.Property<int>("GPAInputId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GPAInputId"));

                    b.HasKey("GPAInputId");

                    b.ToTable("GPAInputs");
                });

            modelBuilder.Entity("CPICPP.Models.GPAVerification", b =>
                {
                    b.Property<int>("GPAVerificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GPAVerificationId"));

                    b.HasKey("GPAVerificationId");

                    b.ToTable("GPAVerifications");
                });

            modelBuilder.Entity("CPICPP.Models.Institution", b =>
                {
                    b.Property<int>("InstitutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionId"));

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstitutionId");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("CPICPP.Models.InstitutionAdmissionRequirement", b =>
                {
                    b.Property<int>("InstitutionAdmissionRequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionAdmissionRequirementId"));

                    b.HasKey("InstitutionAdmissionRequirementId");

                    b.ToTable("InstitutionAdmissionRequirements");
                });

            modelBuilder.Entity("CPICPP.Models.InstitutionAlumni", b =>
                {
                    b.Property<int>("InstitutionAlumniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionAlumniId"));

                    b.HasKey("InstitutionAlumniId");

                    b.ToTable("InstitutionAlumnis");
                });

            modelBuilder.Entity("CPICPP.Models.InstitutionCampusResource", b =>
                {
                    b.Property<int>("InstitutionCampusResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionCampusResourceId"));

                    b.HasKey("InstitutionCampusResourceId");

                    b.ToTable("InstitutionCampusResources");
                });

            modelBuilder.Entity("CPICPP.Models.InstitutionProgram", b =>
                {
                    b.Property<int>("InstitutionProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionProgramId"));

                    b.HasKey("InstitutionProgramId");

                    b.ToTable("InstitutionPrograms");
                });

            modelBuilder.Entity("CPICPP.Models.InstitutionRanking", b =>
                {
                    b.Property<int>("InstitutionRankingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionRankingId"));

                    b.HasKey("InstitutionRankingId");

                    b.ToTable("InstitutionRanking");
                });

            modelBuilder.Entity("CPICPP.Models.InstitutionReview", b =>
                {
                    b.Property<int>("InstitutionReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionReviewId"));

                    b.HasKey("InstitutionReviewId");

                    b.ToTable("InstitutionReviews");
                });

            modelBuilder.Entity("CPICPP.Models.InterestAssessment", b =>
                {
                    b.Property<int>("InterestAssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestAssessmentId"));

                    b.HasKey("InterestAssessmentId");

                    b.ToTable("InterestAssessments");
                });

            modelBuilder.Entity("CPICPP.Models.InterestCareerPathAlignment", b =>
                {
                    b.Property<int>("InterestCareerPathAlignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestCareerPathAlignmentId"));

                    b.HasKey("InterestCareerPathAlignmentId");

                    b.ToTable("InterestCareerPathAlignments");
                });

            modelBuilder.Entity("CPICPP.Models.InterestEvaluation", b =>
                {
                    b.Property<int>("InterestEvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestEvaluationId"));

                    b.HasKey("InterestEvaluationId");

                    b.ToTable("InterestEvaluations");
                });

            modelBuilder.Entity("CPICPP.Models.InterestProfile", b =>
                {
                    b.Property<int>("InterestProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestProfileId"));

                    b.HasKey("InterestProfileId");

                    b.ToTable("InterestProfiles");
                });

            modelBuilder.Entity("CPICPP.Models.Milestone", b =>
                {
                    b.Property<int>("MilestoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MilestoneId"));

                    b.HasKey("MilestoneId");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("CPICPP.Models.PostalCode", b =>
                {
                    b.Property<int>("PostalCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostalCodeId"));

                    b.HasKey("PostalCodeId");

                    b.ToTable("PostalCodes");
                });

            modelBuilder.Entity("CPICPP.Models.ProgressTracking", b =>
                {
                    b.Property<int>("ProgressTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressTrackingId"));

                    b.HasKey("ProgressTrackingId");

                    b.ToTable("ProgressTrackings");
                });

            modelBuilder.Entity("CPICPP.Models.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvinceId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceId");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("CPICPP.Models.QuestionnaireQuestion", b =>
                {
                    b.Property<int>("QuestionnaireQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionnaireQuestionId"));

                    b.Property<string>("Dimension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionnaireQuestionId");

                    b.ToTable("QuestionnaireQuestions");
                });

            modelBuilder.Entity("CPICPP.Models.QuestionnaireResponse", b =>
                {
                    b.Property<int>("QuestionnaireResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionnaireResponseId"));

                    b.Property<string>("MBTIType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionnaireQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isYes")
                        .HasColumnType("bit");

                    b.HasKey("QuestionnaireResponseId");

                    b.HasIndex("QuestionnaireQuestionId");

                    b.ToTable("QuestionnaireResponses");
                });

            modelBuilder.Entity("CPICPP.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"));

                    b.Property<string>("SchoolAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("CPICPP.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("subjectcategoryid")
                        .HasColumnType("int");

                    b.HasKey("SubjectId");

                    b.HasIndex("subjectcategoryid");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("CPICPP.Models.SubjectCategory", b =>
                {
                    b.Property<int>("SubjectCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectCategoryId"));

                    b.Property<string>("SubjectCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectCategoryId");

                    b.ToTable("SubjectCategorys");
                });

            modelBuilder.Entity("CPICPP.Models.TestSession", b =>
                {
                    b.Property<int>("TestSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestSessionId"));

                    b.Property<string>("GeneratedMBTIType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionsAskedJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserResponsesJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestSessionId");

                    b.ToTable("TestSessions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CPICPP.Models.CareerJob", b =>
                {
                    b.HasOne("CPICPP.Models.CareerCategory", "CareerCategory")
                        .WithMany()
                        .HasForeignKey("CareerCategoryId");

                    b.Navigation("CareerCategory");
                });

            modelBuilder.Entity("CPICPP.Models.Province", b =>
                {
                    b.HasOne("CPICPP.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CPICPP.Models.QuestionnaireResponse", b =>
                {
                    b.HasOne("CPICPP.Models.QuestionnaireQuestion", "QuestionnaireQuestion")
                        .WithMany("Responses")
                        .HasForeignKey("QuestionnaireQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionnaireQuestion");
                });

            modelBuilder.Entity("CPICPP.Models.Subject", b =>
                {
                    b.HasOne("CPICPP.Models.SubjectCategory", "SubjectCategory")
                        .WithMany()
                        .HasForeignKey("subjectcategoryid");

                    b.Navigation("SubjectCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CPICPP.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CPICPP.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPICPP.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CPICPP.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPICPP.Models.QuestionnaireQuestion", b =>
                {
                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
