using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Service.Migrations
{
    public partial class ClientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "client_email",
                table: "orders",
                type: "text",
                nullable: true);

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
                    table.PrimaryKey("PK_CLIENTS", x => x.email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CLIENT_CLIENT_EMAIL",
                table: "orders",
                column: "client_email");

            migrationBuilder.AddForeignKey(
                name: "ORDERS_CLIENT_CLIENT_EMAIL_FK",
                table: "orders",
                column: "client_email",
                principalTable: "clients",
                principalColumn: "email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ORDERS_CLIENT_CLIENT_EMAIL_FK",
                table: "orders");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropIndex(
                name: "IX_ORDERS_CLIENT_CLIENT_EMAIL",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "client_email",
                table: "orders");
        }
    }
}
