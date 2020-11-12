using Microsoft.EntityFrameworkCore.Migrations;

namespace KU.WebAPI.Migrations
{
    public partial class CityRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_City_CityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "City");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "City",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_City_CityId",
                table: "Customers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
