using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreMigration.Migrations
{
    public partial class Weizen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Weizen",
                table: "Pizza",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weizen",
                table: "Pizza");
        }
    }
}
