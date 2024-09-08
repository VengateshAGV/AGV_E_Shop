using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataConnections.Migrations
{
    /// <inheritdoc />
    public partial class DisMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Models",
                newName: "DisCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisCount",
                table: "Models",
                newName: "Discount");
        }
    }
}
