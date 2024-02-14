using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetePizza.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Pizza_PizzaId",
                table: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_PizzaId",
                table: "Ingrediente");

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Ingrediente");

            migrationBuilder.CreateTable(
                name: "PizzaIngrediente",
                columns: table => new
                {
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    IngredienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngrediente", x => new { x.PizzaID, x.IngredienteID });
                    table.ForeignKey(
                        name: "FK_PizzaIngrediente_Ingrediente_IngredienteID",
                        column: x => x.IngredienteID,
                        principalTable: "Ingrediente",
                        principalColumn: "IngredienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngrediente_Pizza_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizza",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 1,
                column: "NombreIngrediente",
                value: "Piña");

            migrationBuilder.UpdateData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 2,
                columns: new[] { "NombreIngrediente", "Origen" },
                values: new object[] { "Jamón york", "Animal" });

            migrationBuilder.UpdateData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 3,
                columns: new[] { "NombreIngrediente", "Origen" },
                values: new object[] { "Carne picada", "Animal" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[,]
                {
                    { 1, "yes", "Hawaiana" },
                    { 2, "yes", "Barbacoa" }
                });

            migrationBuilder.InsertData(
                table: "PizzaIngrediente",
                columns: new[] { "IngredienteID", "PizzaID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PizzaIngrediente",
                columns: new[] { "IngredienteID", "PizzaID" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "PizzaIngrediente",
                columns: new[] { "IngredienteID", "PizzaID" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngrediente_IngredienteID",
                table: "PizzaIngrediente",
                column: "IngredienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngrediente");

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaID",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Ingrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[] { 1, "Yes", "Carbonara" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[] { 2, "Yes", "Barbacoa" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaID", "IsGlutenFree", "Nombre" },
                values: new object[] { 3, "No", "Hawaina" });

            migrationBuilder.UpdateData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 1,
                columns: new[] { "NombreIngrediente", "PizzaId" },
                values: new object[] { "Champiñon", 1 });

            migrationBuilder.UpdateData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 2,
                columns: new[] { "NombreIngrediente", "Origen", "PizzaId" },
                values: new object[] { "Oliva", "Vegetal", 2 });

            migrationBuilder.UpdateData(
                table: "Ingrediente",
                keyColumn: "IngredienteId",
                keyValue: 3,
                columns: new[] { "NombreIngrediente", "Origen", "PizzaId" },
                values: new object[] { "Piña", "Vegetal", 1 });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "IngredienteId", "NombreIngrediente", "Origen", "PizzaId" },
                values: new object[] { 4, "Pollo", "Animal", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_PizzaId",
                table: "Ingrediente",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediente_Pizza_PizzaId",
                table: "Ingrediente",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "PizzaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
