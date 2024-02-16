using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cpu_price_monitor.Migrations
{
    /// <inheritdoc />
    public partial class CpuIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Cpus_CpuId",
                table: "Prices");

            migrationBuilder.AlterColumn<int>(
                name: "CpuId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Cpus_CpuId",
                table: "Prices",
                column: "CpuId",
                principalTable: "Cpus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Cpus_CpuId",
                table: "Prices");

            migrationBuilder.AlterColumn<int>(
                name: "CpuId",
                table: "Prices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Cpus_CpuId",
                table: "Prices",
                column: "CpuId",
                principalTable: "Cpus",
                principalColumn: "Id");
        }
    }
}
