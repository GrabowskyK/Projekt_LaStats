using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_LaStats.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeAsStringToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Events");
        }
    }
}
