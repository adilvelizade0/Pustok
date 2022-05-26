using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class InitialMigrationUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "Sliders");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Sliders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Sliders");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
