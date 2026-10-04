using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class Booked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Booked",
                table: "Items");
        }
    }
}
