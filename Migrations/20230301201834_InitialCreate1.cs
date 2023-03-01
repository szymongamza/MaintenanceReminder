using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceReminder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Maintainer_MaintainerId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Device",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaintainerId",
                table: "Device",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Maintainer_MaintainerId",
                table: "Device",
                column: "MaintainerId",
                principalTable: "Maintainer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Maintainer_MaintainerId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Device",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaintainerId",
                table: "Device",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Maintainer_MaintainerId",
                table: "Device",
                column: "MaintainerId",
                principalTable: "Maintainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
