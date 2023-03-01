using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceReminder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Device",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_PlaceId",
                table: "Device",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Place_PlaceId",
                table: "Device",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Place_PlaceId",
                table: "Device");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Device_PlaceId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Device");
        }
    }
}
