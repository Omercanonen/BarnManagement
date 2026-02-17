using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarnManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeMonthField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeMonth",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeMonth",
                table: "Animals");
        }
    }
}
