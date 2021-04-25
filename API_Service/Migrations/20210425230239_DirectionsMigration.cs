using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Service.Migrations
{
    public partial class DirectionsMigration : Migration
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
                    table.PrimaryKey("PK_ADMIN", x => x.username);
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
                    table.PrimaryKey("PK_dDIRECTIONS_CLIENTS", x => x.direction);
                    table.ForeignKey(
                        name: "DIRECTIONS_CLIENTS_CLIENTS_FK",
                        column: x => x.client_email,
                        principalTable: "clients",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DIRECTIONS_CLIENTS_CLIENTS",
                table: "directions_clients",
                column: "client_email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "directions_clients");
        }
    }
}
