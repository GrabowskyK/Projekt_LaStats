using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_LaStats.Migrations
{
    /// <inheritdoc />
    public partial class IsEndedMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnded",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnded",
                table: "Matches");
        }
    }
}
