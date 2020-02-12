using Microsoft.EntityFrameworkCore.Migrations;

namespace Ingenum.Kanban.Data.Migrations
{
    public partial class ModifyFieldLockedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Boards");

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Boards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Boards");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Boards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
