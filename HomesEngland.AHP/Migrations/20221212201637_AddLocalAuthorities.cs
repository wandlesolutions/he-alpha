using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomesEngland.AHP.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalAuthorities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocalAuthorityId",
                table: "Schemes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocalAuthorities",
                columns: table => new
                {
                    LocalAuthorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalAuthorityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAuthorities", x => x.LocalAuthorityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_LocalAuthorityId",
                table: "Schemes",
                column: "LocalAuthorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schemes_LocalAuthorities_LocalAuthorityId",
                table: "Schemes",
                column: "LocalAuthorityId",
                principalTable: "LocalAuthorities",
                principalColumn: "LocalAuthorityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schemes_LocalAuthorities_LocalAuthorityId",
                table: "Schemes");

            migrationBuilder.DropTable(
                name: "LocalAuthorities");

            migrationBuilder.DropIndex(
                name: "IX_Schemes_LocalAuthorityId",
                table: "Schemes");

            migrationBuilder.DropColumn(
                name: "LocalAuthorityId",
                table: "Schemes");
        }
    }
}
