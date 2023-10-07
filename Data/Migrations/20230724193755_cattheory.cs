using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class cattheory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareerCategory",
                columns: table => new
                {
                    CareerCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareerCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerCategory", x => x.CareerCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CareerTheorys",
                columns: table => new
                {
                    CareerTheoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerTheorys", x => x.CareerTheoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerCategory");

            migrationBuilder.DropTable(
                name: "CareerTheorys");
        }
    }
}
