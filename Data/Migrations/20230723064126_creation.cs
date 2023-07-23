using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeCity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolCity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolCountry",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolPostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolProvince",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AcademicPerformanceEvaluations",
                columns: table => new
                {
                    AcademicPerformanceEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPerformanceEvaluations", x => x.AcademicPerformanceEvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "APSAnalysises",
                columns: table => new
                {
                    APSAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APSAnalysises", x => x.APSAnalysisId);
                });

            migrationBuilder.CreateTable(
                name: "APSInputs",
                columns: table => new
                {
                    APSInputId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeLan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeLanScore = table.Column<int>(type: "int", nullable: false),
                    FirstLan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstLanScore = table.Column<int>(type: "int", nullable: false),
                    OptionalLan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionalLanScore = table.Column<int>(type: "int", nullable: false),
                    Math = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MathScore = table.Column<int>(type: "int", nullable: false),
                    LO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOScore = table.Column<int>(type: "int", nullable: false),
                    AddSubject1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddSubject1Score = table.Column<int>(type: "int", nullable: false),
                    AddSubject2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddSubject2Score = table.Column<int>(type: "int", nullable: false),
                    AddSubject3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddSubject3Score = table.Column<int>(type: "int", nullable: false),
                    AddSubject4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddSubject4Score = table.Column<int>(type: "int", nullable: false),
                    AddSubject5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddSubject5Score = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APSInputs", x => x.APSInputId);
                });

            migrationBuilder.CreateTable(
                name: "APSVerifications",
                columns: table => new
                {
                    APSVerificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APSVerifications", x => x.APSVerificationId);
                });

            migrationBuilder.CreateTable(
                name: "CareerJobs",
                columns: table => new
                {
                    CareerJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerJobs", x => x.CareerJobId);
                });

            migrationBuilder.CreateTable(
                name: "CareerPathAlignments",
                columns: table => new
                {
                    CareerPathAlignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerPathAlignments", x => x.CareerPathAlignmentId);
                });

            migrationBuilder.CreateTable(
                name: "CareerRecommendations",
                columns: table => new
                {
                    CareerRecommendationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerRecommendations", x => x.CareerRecommendationId);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "GPAAnalysises",
                columns: table => new
                {
                    GPAAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPAAnalysises", x => x.GPAAnalysisId);
                });

            migrationBuilder.CreateTable(
                name: "GPAInputs",
                columns: table => new
                {
                    GPAInputId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPAInputs", x => x.GPAInputId);
                });

            migrationBuilder.CreateTable(
                name: "GPAVerifications",
                columns: table => new
                {
                    GPAVerificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPAVerifications", x => x.GPAVerificationId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionAdmissionRequirements",
                columns: table => new
                {
                    InstitutionAdmissionRequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionAdmissionRequirements", x => x.InstitutionAdmissionRequirementId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionAlumnis",
                columns: table => new
                {
                    InstitutionAlumniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionAlumnis", x => x.InstitutionAlumniId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionCampusResources",
                columns: table => new
                {
                    InstitutionCampusResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionCampusResources", x => x.InstitutionCampusResourceId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionPrograms",
                columns: table => new
                {
                    InstitutionProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionPrograms", x => x.InstitutionProgramId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionRanking",
                columns: table => new
                {
                    InstitutionRankingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionRanking", x => x.InstitutionRankingId);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionReviews",
                columns: table => new
                {
                    InstitutionReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionReviews", x => x.InstitutionReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "InterestAssessments",
                columns: table => new
                {
                    InterestAssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestAssessments", x => x.InterestAssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "InterestCareerPathAlignments",
                columns: table => new
                {
                    InterestCareerPathAlignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestCareerPathAlignments", x => x.InterestCareerPathAlignmentId);
                });

            migrationBuilder.CreateTable(
                name: "InterestEvaluations",
                columns: table => new
                {
                    InterestEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestEvaluations", x => x.InterestEvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "InterestProfiles",
                columns: table => new
                {
                    InterestProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestProfiles", x => x.InterestProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    MilestoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.MilestoneId);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    PostalCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.PostalCodeId);
                });

            migrationBuilder.CreateTable(
                name: "ProgressTrackings",
                columns: table => new
                {
                    ProgressTrackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressTrackings", x => x.ProgressTrackingId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireQuestions",
                columns: table => new
                {
                    QuestionnaireQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireQuestions", x => x.QuestionnaireQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireResponses",
                columns: table => new
                {
                    QuestionnaireResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireResponses", x => x.QuestionnaireResponseId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategorys",
                columns: table => new
                {
                    SubjectCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategorys", x => x.SubjectCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Provinces_Countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countrys",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectcategoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_SubjectCategorys_subjectcategoryid",
                        column: x => x.subjectcategoryid,
                        principalTable: "SubjectCategorys",
                        principalColumn: "SubjectCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_subjectcategoryid",
                table: "Subjects",
                column: "subjectcategoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicPerformanceEvaluations");

            migrationBuilder.DropTable(
                name: "APSAnalysises");

            migrationBuilder.DropTable(
                name: "APSInputs");

            migrationBuilder.DropTable(
                name: "APSVerifications");

            migrationBuilder.DropTable(
                name: "CareerJobs");

            migrationBuilder.DropTable(
                name: "CareerPathAlignments");

            migrationBuilder.DropTable(
                name: "CareerRecommendations");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "GPAAnalysises");

            migrationBuilder.DropTable(
                name: "GPAInputs");

            migrationBuilder.DropTable(
                name: "GPAVerifications");

            migrationBuilder.DropTable(
                name: "InstitutionAdmissionRequirements");

            migrationBuilder.DropTable(
                name: "InstitutionAlumnis");

            migrationBuilder.DropTable(
                name: "InstitutionCampusResources");

            migrationBuilder.DropTable(
                name: "InstitutionPrograms");

            migrationBuilder.DropTable(
                name: "InstitutionRanking");

            migrationBuilder.DropTable(
                name: "InstitutionReviews");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "InterestAssessments");

            migrationBuilder.DropTable(
                name: "InterestCareerPathAlignments");

            migrationBuilder.DropTable(
                name: "InterestEvaluations");

            migrationBuilder.DropTable(
                name: "InterestProfiles");

            migrationBuilder.DropTable(
                name: "Milestones");

            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "ProgressTrackings");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "QuestionnaireQuestions");

            migrationBuilder.DropTable(
                name: "QuestionnaireResponses");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Countrys");

            migrationBuilder.DropTable(
                name: "SubjectCategorys");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolPostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolProvince",
                table: "AspNetUsers");
        }
    }
}
