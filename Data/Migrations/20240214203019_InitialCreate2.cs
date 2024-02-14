using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetePizza.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGlutenFree",
                table: "Pizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsGlutenFree",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 1,
                column: "IsGlutenFree",
                value: "yes");

            migrationBuilder.UpdateData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 2,
                column: "IsGlutenFree",
                value: "yes");
        }
    }
}
