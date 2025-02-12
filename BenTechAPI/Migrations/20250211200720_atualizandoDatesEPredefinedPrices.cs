using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class atualizandoDatesEPredefinedPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dates_PredefinedPrices_predefinedPricesColorCode",
                table: "dates");

            migrationBuilder.DropIndex(
                name: "IX_dates_predefinedPricesColorCode",
                table: "dates");

            migrationBuilder.DropColumn(
                name: "predefinedPricesColorCode",
                table: "dates");

            migrationBuilder.CreateIndex(
                name: "IX_dates_ColorCode",
                table: "dates",
                column: "ColorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_dates_PredefinedPrices_ColorCode",
                table: "dates",
                column: "ColorCode",
                principalTable: "PredefinedPrices",
                principalColumn: "ColorCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dates_PredefinedPrices_ColorCode",
                table: "dates");

            migrationBuilder.DropIndex(
                name: "IX_dates_ColorCode",
                table: "dates");

            migrationBuilder.AddColumn<string>(
                name: "predefinedPricesColorCode",
                table: "dates",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_dates_predefinedPricesColorCode",
                table: "dates",
                column: "predefinedPricesColorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_dates_PredefinedPrices_predefinedPricesColorCode",
                table: "dates",
                column: "predefinedPricesColorCode",
                principalTable: "PredefinedPrices",
                principalColumn: "ColorCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
