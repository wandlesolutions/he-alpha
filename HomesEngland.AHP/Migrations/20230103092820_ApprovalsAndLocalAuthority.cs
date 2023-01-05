using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalsAndLocalAuthority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalAuthority",
                table: "Properties");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Programmes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Programmes");

            migrationBuilder.AddColumn<string>(
                name: "LocalAuthority",
                table: "Properties",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}
