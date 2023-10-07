using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireResponses_QuestionnaireQuestions_QuestionnaireQuestionId",
                table: "QuestionnaireResponses");

            migrationBuilder.AlterColumn<string>(
                name: "UserResponsesJson",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionsAskedJson",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MBTIType",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireResponses_QuestionnaireQuestions_QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                column: "QuestionnaireQuestionId",
                principalTable: "QuestionnaireQuestions",
                principalColumn: "QuestionnaireQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireResponses_QuestionnaireQuestions_QuestionnaireQuestionId",
                table: "QuestionnaireResponses");

            migrationBuilder.AlterColumn<string>(
                name: "UserResponsesJson",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionsAskedJson",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MBTIType",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireResponses_QuestionnaireQuestions_QuestionnaireQuestionId",
                table: "QuestionnaireResponses",
                column: "QuestionnaireQuestionId",
                principalTable: "QuestionnaireQuestions",
                principalColumn: "QuestionnaireQuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
