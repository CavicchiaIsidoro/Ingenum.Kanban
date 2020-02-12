using Microsoft.EntityFrameworkCore.Migrations;

namespace Ingenum.Kanban.Data.Migrations
{
    public partial class ModifTaskDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Tasks");
        }
    }
}
