using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    public partial class InitialCreatePizzas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Number);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "0987654321", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "09876543274", "Ivan Badia" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "1234567890", "John Doe" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Pizzas_BankAccountId",
                table: "Transactions",
                column: "BankAccountId",
                principalTable: "Pizzas",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Pizzas_BankAccountId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Number);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "0987654321", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "09876543274", "Ivan Badia" });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "1234567890", "John Doe" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountId",
                table: "Transactions",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
