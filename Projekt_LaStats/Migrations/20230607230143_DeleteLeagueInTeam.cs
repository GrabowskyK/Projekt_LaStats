using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_LaStats.Migrations
{
    /// <inheritdoc />
    public partial class DeleteLeagueInTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_League",
                table: "Team");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_League",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
