using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPICPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class removingoptinollan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionalLan",
                table: "APSInputs");

            migrationBuilder.DropColumn(
                name: "OptionalLanScore",
                table: "APSInputs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionalLan",
                table: "APSInputs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OptionalLanScore",
                table: "APSInputs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
