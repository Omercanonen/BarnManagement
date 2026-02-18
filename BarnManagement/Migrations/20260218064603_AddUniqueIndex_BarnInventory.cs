using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarnManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndex_BarnInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BarnInventories_BarnId",
                table: "BarnInventories");

            migrationBuilder.CreateIndex(
                name: "IX_BarnInventories_BarnId_ProductId",
                table: "BarnInventories",
                columns: new[] { "BarnId", "ProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BarnInventories_BarnId_ProductId",
                table: "BarnInventories");

            migrationBuilder.CreateIndex(
                name: "IX_BarnInventories_BarnId",
                table: "BarnInventories",
                column: "BarnId");
        }
    }
}
