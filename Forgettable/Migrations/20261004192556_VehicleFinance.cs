using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class VehicleFinance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgreementNumber",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPayment",
                table: "Items",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceType",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lender",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MileageAllowance",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleFinance_Registration",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FinalPayment",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FinanceType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Lender",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MileageAllowance",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "VehicleFinance_Registration",
                table: "Items");
        }
    }
}
