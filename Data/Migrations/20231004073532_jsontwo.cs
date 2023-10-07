using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class jsontwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionsAskedJson",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserResponsesJson",
                table: "QuestionnaireResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionsAskedJson",
                table: "QuestionnaireResponses");

            migrationBuilder.DropColumn(
                name: "UserResponsesJson",
                table: "QuestionnaireResponses");
        }
    }
}
