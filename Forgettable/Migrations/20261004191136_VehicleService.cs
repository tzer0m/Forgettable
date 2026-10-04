using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class VehicleService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleService_Registration",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleService_Registration",
                table: "Items");
        }
    }
}
