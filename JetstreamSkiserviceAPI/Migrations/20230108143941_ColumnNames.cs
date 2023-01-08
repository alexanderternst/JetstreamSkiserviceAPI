using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetstreamSkiserviceAPI.Migrations
{
    public partial class ColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Priority_priority_id",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Service_service_id",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Status_status_id",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "counter",
                table: "Users",
                newName: "Counter");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status_name",
                table: "Status",
                newName: "Status_name");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "Status",
                newName: "Status_id");

            migrationBuilder.RenameColumn(
                name: "service_name",
                table: "Service",
                newName: "Service_name");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "Service",
                newName: "Service_id");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "Registrations",
                newName: "Status_id");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "Registrations",
                newName: "Service_id");

            migrationBuilder.RenameColumn(
                name: "priority_id",
                table: "Registrations",
                newName: "Priority_id");

            migrationBuilder.RenameColumn(
                name: "pickup_date",
                table: "Registrations",
                newName: "Pickup_date");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Registrations",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Registrations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Registrations",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Registrations",
                newName: "Create_date");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Registrations",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Registrations",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_status_id",
                table: "Registrations",
                newName: "IX_Registrations_Status_id");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_service_id",
                table: "Registrations",
                newName: "IX_Registrations_Service_id");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_priority_id",
                table: "Registrations",
                newName: "IX_Registrations_Priority_id");

            migrationBuilder.RenameColumn(
                name: "priority_name",
                table: "Priority",
                newName: "Priority_name");

            migrationBuilder.RenameColumn(
                name: "priority_id",
                table: "Priority",
                newName: "Priority_id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "Counter",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status_name",
                table: "Status",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Service_name",
                table: "Service",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "Status_id",
                table: "Registrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Service_id",
                table: "Registrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Priority_id",
                table: "Registrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Priority_name",
                table: "Priority",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Priority_Priority_id",
                table: "Registrations",
                column: "Priority_id",
                principalTable: "Priority",
                principalColumn: "Priority_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Service_Service_id",
                table: "Registrations",
                column: "Service_id",
                principalTable: "Service",
                principalColumn: "Service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Status_Status_id",
                table: "Registrations",
                column: "Status_id",
                principalTable: "Status",
                principalColumn: "Status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Priority_Priority_id",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Service_Service_id",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Status_Status_id",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Counter",
                table: "Users",
                newName: "counter");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Status_name",
                table: "Status",
                newName: "status_name");

            migrationBuilder.RenameColumn(
                name: "Status_id",
                table: "Status",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "Service_name",
                table: "Service",
                newName: "service_name");

            migrationBuilder.RenameColumn(
                name: "Service_id",
                table: "Service",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "Status_id",
                table: "Registrations",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "Service_id",
                table: "Registrations",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "Priority_id",
                table: "Registrations",
                newName: "priority_id");

            migrationBuilder.RenameColumn(
                name: "Pickup_date",
                table: "Registrations",
                newName: "pickup_date");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Registrations",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Registrations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Registrations",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Create_date",
                table: "Registrations",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Registrations",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Registrations",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_Status_id",
                table: "Registrations",
                newName: "IX_Registrations_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_Service_id",
                table: "Registrations",
                newName: "IX_Registrations_service_id");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_Priority_id",
                table: "Registrations",
                newName: "IX_Registrations_priority_id");

            migrationBuilder.RenameColumn(
                name: "Priority_name",
                table: "Priority",
                newName: "priority_name");

            migrationBuilder.RenameColumn(
                name: "Priority_id",
                table: "Priority",
                newName: "priority_id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "counter",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status_name",
                table: "Status",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "service_name",
                table: "Service",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "service_id",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "priority_id",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "Registrations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "priority_name",
                table: "Priority",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Priority_priority_id",
                table: "Registrations",
                column: "priority_id",
                principalTable: "Priority",
                principalColumn: "priority_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Service_service_id",
                table: "Registrations",
                column: "service_id",
                principalTable: "Service",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Status_status_id",
                table: "Registrations",
                column: "status_id",
                principalTable: "Status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
