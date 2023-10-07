using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_SubjectCategorys_subjectcategoryid",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "subjectcategoryid",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MBTIType",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isYes",
                table: "QuestionnaireResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "QuestionnaireQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "QuestionnaireQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstitutionName",
                table: "Institutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CareerTheoryDescription",
                table: "CareerTheorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CareerTheoryName",
                table: "CareerTheorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CareerCategoryId",
                table: "CareerJobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CareerJobDescription",
                table: "CareerJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CareerJobName",
                table: "CareerJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "careercode",
                table: "CareerCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "careertypecode",
                table: "CareerCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "APSInputs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireResponses_QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                column: "QuestionnaireQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerJobs_CareerCategoryId",
                table: "CareerJobs",
                column: "CareerCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerJobs_CareerCategory_CareerCategoryId",
                table: "CareerJobs",
                column: "CareerCategoryId",
                principalTable: "CareerCategory",
                principalColumn: "CareerCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireResponses_QuestionnaireQuestions_QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                column: "QuestionnaireQuestionId",
                principalTable: "QuestionnaireQuestions",
                principalColumn: "QuestionnaireQuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_SubjectCategorys_subjectcategoryid",
                table: "Subjects",
                column: "subjectcategoryid",
                principalTable: "SubjectCategorys",
                principalColumn: "SubjectCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerJobs_CareerCategory_CareerCategoryId",
                table: "CareerJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireResponses_QuestionnaireQuestions_QuestionnaireQuestionId",
                table: "QuestionnaireResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_SubjectCategorys_subjectcategoryid",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireResponses_QuestionnaireQuestionId",
                table: "QuestionnaireResponses");

            migrationBuilder.DropIndex(
                name: "IX_CareerJobs_CareerCategoryId",
                table: "CareerJobs");

            migrationBuilder.DropColumn(
                name: "MBTIType",
                table: "QuestionnaireResponses");

            migrationBuilder.DropColumn(
                name: "QuestionnaireQuestionId",
                table: "QuestionnaireResponses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuestionnaireResponses");

            migrationBuilder.DropColumn(
                name: "isYes",
                table: "QuestionnaireResponses");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "QuestionnaireQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "QuestionnaireQuestions");

            migrationBuilder.DropColumn(
                name: "InstitutionName",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "CareerTheoryDescription",
                table: "CareerTheorys");

            migrationBuilder.DropColumn(
                name: "CareerTheoryName",
                table: "CareerTheorys");

            migrationBuilder.DropColumn(
                name: "CareerCategoryId",
                table: "CareerJobs");

            migrationBuilder.DropColumn(
                name: "CareerJobDescription",
                table: "CareerJobs");

            migrationBuilder.DropColumn(
                name: "CareerJobName",
                table: "CareerJobs");

            migrationBuilder.DropColumn(
                name: "careercode",
                table: "CareerCategory");

            migrationBuilder.DropColumn(
                name: "careertypecode",
                table: "CareerCategory");

            migrationBuilder.DropColumn(
                name: "TestName",
                table: "APSInputs");

            migrationBuilder.AlterColumn<int>(
                name: "subjectcategoryid",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_SubjectCategorys_subjectcategoryid",
                table: "Subjects",
                column: "subjectcategoryid",
                principalTable: "SubjectCategorys",
                principalColumn: "SubjectCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
