using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class StatusCodeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Schemes");

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Schemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "Schemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Schemes");

            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "Schemes");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Schemes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
