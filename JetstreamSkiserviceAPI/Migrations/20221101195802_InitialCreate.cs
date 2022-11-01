using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamSkiserviceAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    service = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pickup_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Registrations_Status_status_id",
                        column: x => x.status_id,
                        principalTable: "Status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_status_id",
                table: "Registrations",
                column: "status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
