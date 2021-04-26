using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API_Service.Migrations
{
    public partial class FullMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    last_name1 = table.Column<string>(type: "text", nullable: false),
                    last_name2 = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    continent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.email);
                });

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
                    table.PrimaryKey("PK_device_types", x => x.name);
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
                    table.PrimaryKey("PK_distributors", x => x.legal_card);
                });

            migrationBuilder.CreateTable(
                name: "chambers",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    client_email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chambers", x => x.name);
                    table.ForeignKey(
                        name: "FK_chambers_clients_client_email",
                        column: x => x.client_email,
                        principalTable: "clients",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "directions_clients",
                columns: table => new
                {
                    direction = table.Column<string>(type: "text", nullable: false),
                    client_email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directions_clients", x => x.direction);
                    table.ForeignKey(
                        name: "FK_directions_clients_clients_client_email",
                        column: x => x.client_email,
                        principalTable: "clients",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    serial_number = table.Column<int>(type: "integer", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    electric_usage = table.Column<int>(type: "integer", nullable: false),
                    device_type_name = table.Column<string>(type: "text", nullable: true),
                    client_email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.serial_number);
                    table.ForeignKey(
                        name: "FK_devices_clients_client_email",
                        column: x => x.client_email,
                        principalTable: "clients",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_devices_device_types_device_type_name",
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
                    table.PrimaryKey("PK_device_distributor", x => new { x.devices_serial_number, x.distributors_legal_card });
                    table.ForeignKey(
                        name: "FK_device_distributor_devices_devices_serial_number",
                        column: x => x.devices_serial_number,
                        principalTable: "devices",
                        principalColumn: "serial_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_device_distributor_distributors_distributors_legal_card",
                        column: x => x.distributors_legal_card,
                        principalTable: "distributors",
                        principalColumn: "legal_card",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    consecutive = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bill_number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    price = table.Column<int>(type: "integer", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "Date", nullable: false),
                    purchase_time = table.Column<string>(type: "text", nullable: false),
                    client_email = table.Column<string>(type: "text", nullable: true),
                    device_serial_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.consecutive);
                    table.ForeignKey(
                        name: "FK_orders_clients_client_email",
                        column: x => x.client_email,
                        principalTable: "clients",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_devices_device_serial_number",
                        column: x => x.device_serial_number,
                        principalTable: "devices",
                        principalColumn: "serial_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chambers_client_email",
                table: "chambers",
                column: "client_email");

            migrationBuilder.CreateIndex(
                name: "IX_device_distributor_distributors_legal_card",
                table: "device_distributor",
                column: "distributors_legal_card");

            migrationBuilder.CreateIndex(
                name: "IX_devices_client_email",
                table: "devices",
                column: "client_email");

            migrationBuilder.CreateIndex(
                name: "IX_devices_device_type_name",
                table: "devices",
                column: "device_type_name");

            migrationBuilder.CreateIndex(
                name: "IX_directions_clients_client_email",
                table: "directions_clients",
                column: "client_email");

            migrationBuilder.CreateIndex(
                name: "IX_orders_client_email",
                table: "orders",
                column: "client_email");

            migrationBuilder.CreateIndex(
                name: "IX_orders_device_serial_number",
                table: "orders",
                column: "device_serial_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "chambers");

            migrationBuilder.DropTable(
                name: "device_distributor");

            migrationBuilder.DropTable(
                name: "directions_clients");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "distributors");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "device_types");
        }
    }
}
