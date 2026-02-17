using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarnManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddCanProduceAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnimalSpecies",
                keyColumn: "AnimalSpeciesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnimalSpecies",
                keyColumn: "AnimalSpeciesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnimalSpecies",
                keyColumn: "AnimalSpeciesId",
                keyValue: 3);

            migrationBuilder.AddColumn<bool>(
                name: "CanProduce",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanProduce",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "AnimalSpecies",
                columns: new[] { "AnimalSpeciesId", "AnimalSpeciesLifeSpan", "AnimalSpeciesName", "AnimalSpeciesPurchasePrice", "IsActive" },
                values: new object[,]
                {
                    { 1, 10, "Sheep", 200m, true },
                    { 2, 20, "Cow", 1500m, true },
                    { 3, 5, "Chicken", 50m, true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AnimalSpeciesId", "IsActive", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, 1, true, "Wool", 15m },
                    { 2, 2, true, "Milk", 25m },
                    { 3, 3, true, "Egg", 2m }
                });
        }
    }
}
