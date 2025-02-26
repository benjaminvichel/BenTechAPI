using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class NameInPredefinedPricesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PredefinedPrices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PredefinedPrices");
        }
    }
}
