using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class json : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestSessions",
                columns: table => new
                {
                    TestSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserResponsesJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionsAskedJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedMBTIType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessions", x => x.TestSessionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestSessions");
        }
    }
}
