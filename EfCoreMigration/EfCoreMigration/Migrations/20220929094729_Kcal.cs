using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreMigration.Migrations
{
    public partial class Kcal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KCal",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.Sql("SELECT * FROM ALL");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KCal",
                table: "Pizza");
        }
    }
}
