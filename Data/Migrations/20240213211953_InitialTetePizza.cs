using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    public partial class InitialTetePizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Number",
                keyColumnType: "nvarchar(450)",
                keyValue: "09876543274");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Number",
                keyColumnType: "nvarchar(450)",
                keyValue: "0987654321");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Number",
                keyColumnType: "nvarchar(450)",
                keyValue: "1234567890");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Pizza",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "PizzaID",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IsGlutenFree",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza",
                column: "PizzaID");

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreIngrediente = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.IngredienteId);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[] { 1, "Yes", "John Doe" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[] { 2, "Yes", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[] { 3, "No", "Ivan Badia" });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "IngredienteId", "NombreIngrediente", "Origen", "PizzaId" },
                values: new object[,]
                {
                    { 1, "Champiñon", "Vegetal", 1 },
                    { 2, "Oliva", "Vegetal", 2 },
                    { 3, "Piña", "Vegetal", 1 },
                    { 4, "Pollo", "Animal", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_PizzaId",
                table: "Ingrediente",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PizzaID",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "IsGlutenFree",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Pizza",
                newName: "Owner");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Pizza",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza",
                column: "Number");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Pizza_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "Pizza",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "0987654321", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "09876543274", "Ivan Badia" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "1234567890", "John Doe" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "BankAccountId", "Date", "Note" },
                values: new object[,]
                {
                    { 1, 200.00m, "1234567890", new DateTime(2021, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Deposito inicial" },
                    { 2, 300.00m, "1234567890", new DateTime(2021, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), "Deposito" },
                    { 3, -150.00m, "1234567890", new DateTime(2021, 1, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), "Retiro" },
                    { 4, 400.00m, "0987654321", new DateTime(2021, 1, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), "Deposito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankAccountId",
                table: "Transactions",
                column: "BankAccountId");
        }
    }
}
