using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class VehicleInsurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleInsurance_PolicyNumber",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleInsurance_Provider",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleInsurance_Registration",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleInsurance_PolicyNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "VehicleInsurance_Provider",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "VehicleInsurance_Registration",
                table: "Items");
        }
    }
}
