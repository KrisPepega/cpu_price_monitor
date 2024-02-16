using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cpu_price_monitor.Migrations
{
    /// <inheritdoc />
    public partial class AddedLowestPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LowestPrice",
                table: "Cpus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowestPrice",
                table: "Cpus");
        }
    }
}
