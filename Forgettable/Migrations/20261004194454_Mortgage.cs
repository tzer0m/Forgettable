using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class Mortgage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Items",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleFinance_Lender",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "VehicleFinance_Lender",
                table: "Items");
        }
    }
}
