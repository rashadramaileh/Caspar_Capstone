using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixednullabilityagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorTime_DayBlock_DayBlockId",
                table: "InstructorTime");

            migrationBuilder.DropIndex(
                name: "IX_InstructorTime_DayBlockId",
                table: "InstructorTime");

            migrationBuilder.DropColumn(
                name: "DayBlockId",
                table: "InstructorTime");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_DaysBlockId",
                table: "InstructorTime",
                column: "DaysBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorTime_DayBlock_DaysBlockId",
                table: "InstructorTime",
                column: "DaysBlockId",
                principalTable: "DayBlock",
                principalColumn: "DaysBlockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorTime_DayBlock_DaysBlockId",
                table: "InstructorTime");

            migrationBuilder.DropIndex(
                name: "IX_InstructorTime_DaysBlockId",
                table: "InstructorTime");

            migrationBuilder.AddColumn<int>(
                name: "DayBlockId",
                table: "InstructorTime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_DayBlockId",
                table: "InstructorTime",
                column: "DayBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorTime_DayBlock_DayBlockId",
                table: "InstructorTime",
                column: "DayBlockId",
                principalTable: "DayBlock",
                principalColumn: "DaysBlockId");
        }
    }
}
