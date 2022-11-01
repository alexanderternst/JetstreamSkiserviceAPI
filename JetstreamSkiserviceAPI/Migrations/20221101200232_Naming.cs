using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamSkiserviceAPI.Migrations
{
    public partial class Naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Status",
                newName: "status_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_name",
                table: "Status",
                newName: "status");
        }
    }
}
