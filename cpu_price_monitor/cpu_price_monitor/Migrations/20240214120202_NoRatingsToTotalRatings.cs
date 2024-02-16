using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cpu_price_monitor.Migrations
{
    /// <inheritdoc />
    public partial class NoRatingsToTotalRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoRatings",
                table: "Cpus",
                newName: "TotalRatings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalRatings",
                table: "Cpus",
                newName: "NoRatings");
        }
    }
}
