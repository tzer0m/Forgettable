using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class SslCertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "Items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Issuer",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Host",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Issuer",
                table: "Items");
        }
    }
}
