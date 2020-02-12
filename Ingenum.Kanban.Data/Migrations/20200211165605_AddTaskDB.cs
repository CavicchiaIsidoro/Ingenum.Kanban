using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ingenum.Kanban.Data.Migrations
{
    public partial class AddTaskDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Section = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
