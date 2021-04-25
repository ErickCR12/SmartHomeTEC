using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Service.Migrations
{
    public partial class ChamberMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "CHAMBERS_CLIENTS_FK",
                        column: x => x.client_email,
                        principalTable: "clients",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHAMBERS_CLIENTS",
                table: "chambers",
                column: "client_email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chambers");
        }
    }
}
