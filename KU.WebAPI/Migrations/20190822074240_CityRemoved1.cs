using Microsoft.EntityFrameworkCore.Migrations;

namespace KU.WebAPI.Migrations
{
    public partial class CityRemoved1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
