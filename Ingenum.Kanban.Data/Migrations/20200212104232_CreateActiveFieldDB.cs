using Microsoft.EntityFrameworkCore.Migrations;

namespace Ingenum.Kanban.Data.Migrations
{
    public partial class CreateActiveFieldDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Boards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Boards");
        }
    }
}
