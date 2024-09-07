using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewTasks.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    DifficultyLevels = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestTasks_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TestTaskId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagEntity_TestTasks_TestTaskId",
                        column: x => x.TestTaskId,
                        principalTable: "TestTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagEntity_TestTaskId",
                table: "TagEntity",
                column: "TestTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TestTasks_CategoryId",
                table: "TestTasks",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagEntity");

            migrationBuilder.DropTable(
                name: "TestTasks");

            migrationBuilder.DropTable(
                name: "CategoryEntity");
        }
    }
}
