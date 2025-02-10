using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDatesAndPredefinedPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {  
            migrationBuilder.CreateTable(
                name: "PredefinedPrices",
                columns: table => new
                {
                    ColorCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    Double_value = table.Column<double>(type: "float", nullable: false),
                    Single_value = table.Column<double>(type: "float", nullable: false),
                    Triple_value = table.Column<double>(type: "float", nullable: false),
                    Quadruple_value = table.Column<double>(type: "float", nullable: false),
                    Quintuple_value = table.Column<double>(type: "float", nullable: false),
                    Child03To06_value = table.Column<double>(type: "float", nullable: false),
                    Child07To10_value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedPrices", x => x.ColorCode);
                });

            migrationBuilder.CreateTable(
                name: "dates",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColorCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    predefinedPricesColorCode = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dates", x => x.Date);
                    table.ForeignKey(
                        name: "FK_dates_PredefinedPrices_predefinedPricesColorCode",
                        column: x => x.predefinedPricesColorCode,
                        principalTable: "PredefinedPrices",
                        principalColumn: "ColorCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dates_predefinedPricesColorCode",
                table: "dates",
                column: "predefinedPricesColorCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dates");

            migrationBuilder.DropTable(
                name: "PredefinedPrices");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
