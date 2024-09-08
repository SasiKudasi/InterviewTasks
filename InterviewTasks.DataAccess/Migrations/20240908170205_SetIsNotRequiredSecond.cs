using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewTasks.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetIsNotRequiredSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagEntity_TestTasks_TestTaskId",
                table: "TagEntity");

            migrationBuilder.AlterColumn<Guid>(
                name: "TestTaskId",
                table: "TagEntity",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_TagEntity_TestTasks_TestTaskId",
                table: "TagEntity",
                column: "TestTaskId",
                principalTable: "TestTasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagEntity_TestTasks_TestTaskId",
                table: "TagEntity");

            migrationBuilder.AlterColumn<Guid>(
                name: "TestTaskId",
                table: "TagEntity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TagEntity_TestTasks_TestTaskId",
                table: "TagEntity",
                column: "TestTaskId",
                principalTable: "TestTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
