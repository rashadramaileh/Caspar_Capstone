using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_Semester_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semester_SemesterType_SemesterTypesId",
                table: "Semester");

            migrationBuilder.DropIndex(
                name: "IX_Semester_SemesterTypesId",
                table: "Semester");

            migrationBuilder.DropColumn(
                name: "SemesterTypesId",
                table: "Semester");

            migrationBuilder.AddColumn<int>(
                name: "SemesterTypeId",
                table: "Semester",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Semester_SemesterTypeId",
                table: "Semester",
                column: "SemesterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_SemesterType_SemesterTypeId",
                table: "Semester",
                column: "SemesterTypeId",
                principalTable: "SemesterType",
                principalColumn: "SemesterTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semester_SemesterType_SemesterTypeId",
                table: "Semester");

            migrationBuilder.DropIndex(
                name: "IX_Semester_SemesterTypeId",
                table: "Semester");

            migrationBuilder.DropColumn(
                name: "SemesterTypeId",
                table: "Semester");

            migrationBuilder.AddColumn<int>(
                name: "SemesterTypesId",
                table: "Semester",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semester_SemesterTypesId",
                table: "Semester",
                column: "SemesterTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_SemesterType_SemesterTypesId",
                table: "Semester",
                column: "SemesterTypesId",
                principalTable: "SemesterType",
                principalColumn: "SemesterTypeId");
        }
    }
}
