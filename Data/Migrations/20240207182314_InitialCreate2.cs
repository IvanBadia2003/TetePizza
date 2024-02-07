using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "09876543274", "Ivan Badia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Number",
                keyValue: "09876543274");
        }
    }
}
