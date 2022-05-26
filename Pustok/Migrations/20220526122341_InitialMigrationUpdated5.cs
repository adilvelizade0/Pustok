using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class InitialMigrationUpdated5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "PromotionTwos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSmall",
                table: "PromotionTwos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title2",
                table: "PromotionTwos");

            migrationBuilder.DropColumn(
                name: "isSmall",
                table: "PromotionTwos");
        }
    }
}
