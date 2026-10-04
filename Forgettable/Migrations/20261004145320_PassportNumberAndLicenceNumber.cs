using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class PassportNumberAndLicenceNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverNumber",
                table: "Items",
                newName: "LicenceNumber");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "LicenceNumber",
                table: "Items",
                newName: "DriverNumber");
        }
    }
}
