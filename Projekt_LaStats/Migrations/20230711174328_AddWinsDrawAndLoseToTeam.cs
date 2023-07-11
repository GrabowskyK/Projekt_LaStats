using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_LaStats.Migrations
{
    /// <inheritdoc />
    public partial class AddWinsDrawAndLoseToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "draw",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lose",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wins",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "draw",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "lose",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "wins",
                table: "Team");
        }
    }
}
