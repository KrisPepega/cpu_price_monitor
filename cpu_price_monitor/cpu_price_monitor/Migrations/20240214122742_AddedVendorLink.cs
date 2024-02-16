using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cpu_price_monitor.Migrations
{
    /// <inheritdoc />
    public partial class AddedVendorLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendorLink",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorLink",
                table: "Prices");
        }
    }
}
