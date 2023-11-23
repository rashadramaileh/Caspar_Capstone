using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSemesterInRelease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorRelease_Semester_SemesterId",
                table: "InstructorRelease");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "InstructorRelease",
                newName: "SemesterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorRelease_SemesterId",
                table: "InstructorRelease",
                newName: "IX_InstructorRelease_SemesterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorRelease_SemesterType_SemesterTypeId",
                table: "InstructorRelease",
                column: "SemesterTypeId",
                principalTable: "SemesterType",
                principalColumn: "SemesterTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorRelease_SemesterType_SemesterTypeId",
                table: "InstructorRelease");

            migrationBuilder.RenameColumn(
                name: "SemesterTypeId",
                table: "InstructorRelease",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorRelease_SemesterTypeId",
                table: "InstructorRelease",
                newName: "IX_InstructorRelease_SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorRelease_Semester_SemesterId",
                table: "InstructorRelease",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
