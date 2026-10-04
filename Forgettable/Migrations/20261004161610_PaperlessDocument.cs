using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forgettable.Migrations
{
    /// <inheritdoc />
    public partial class PaperlessDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaperlessDocumentId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.Sql("UPDATE \"Items\" SET \"PaperlessDocumentId\" = \"PaperlessDocumentIds\"[1];");

            migrationBuilder.DropColumn(
                name: "PaperlessDocumentIds",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "PaperlessDocumentIds",
                table: "Items",
                type: "integer[]",
                nullable: false,
                defaultValueSql: "'{}'");

            migrationBuilder.Sql("UPDATE \"Items\" SET \"PaperlessDocumentIds\" = ARRAY[\"PaperlessDocumentId\"] WHERE \"PaperlessDocumentId\" IS NOT NULL;");

            migrationBuilder.DropColumn(
                name: "PaperlessDocumentId",
                table: "Items");
        }
    }
}
