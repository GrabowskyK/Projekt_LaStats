using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_LaStats.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberShirtToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShirtNumber",
                table: "Players",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShirtNumber",
                table: "Players");
        }
    }
}
