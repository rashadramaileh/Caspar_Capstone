using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCourseTypeForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseType_CourseTypeId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseTypeId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseTypeId",
                table: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseTypeId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseTypeId",
                table: "Course",
                column: "CourseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseType_CourseTypeId",
                table: "Course",
                column: "CourseTypeId",
                principalTable: "CourseType",
                principalColumn: "CourseTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
