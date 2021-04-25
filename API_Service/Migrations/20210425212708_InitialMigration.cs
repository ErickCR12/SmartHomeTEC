using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API_Service.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "device_types",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    warranty_months = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICE_TYPES", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "distributors",
                columns: table => new
                {
                    legal_card = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    continent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRIBUTORS", x => x.legal_card);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    serial_number = table.Column<int>(type: "integer", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    electric_usage = table.Column<int>(type: "integer", nullable: false),
                    device_type_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICES", x => x.serial_number);
                    table.ForeignKey(
                        name: "DEVICES_DEVICE_TYPES_FK",
                        column: x => x.device_type_name,
                        principalTable: "device_types",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "device_distributor",
                columns: table => new
                {
                    devices_serial_number = table.Column<int>(type: "integer", nullable: false),
                    distributors_legal_card = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICE_DISTRIBUTOR", x => new { x.devices_serial_number, x.distributors_legal_card });
                    table.ForeignKey(
                        name: "DEVICE_DISTRIBUTOR_SERIAL_NUMBER_FK",
                        column: x => x.devices_serial_number,
                        principalTable: "devices",
                        principalColumn: "serial_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "DEVICE_DISTRIBUTOR_LEGAL_CARD_FK",
                        column: x => x.distributors_legal_card,
                        principalTable: "distributors",
                        principalColumn: "legal_card",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEVICE_DISTRIBUTOR_LEGAL_CARD",
                table: "device_distributor",
                column: "distributors_legal_card");

            migrationBuilder.CreateIndex(
                name: "IX_DEVICES_DEVICE_TYPE_NAME",
                table: "devices",
                column: "device_type_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_distributor");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "distributors");

            migrationBuilder.DropTable(
                name: "device_types");
        }
    }
}
