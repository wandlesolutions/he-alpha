using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class PropertySpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProperyId",
                table: "Properties",
                newName: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Properties",
                newName: "ProperyId");
        }
    }
}
