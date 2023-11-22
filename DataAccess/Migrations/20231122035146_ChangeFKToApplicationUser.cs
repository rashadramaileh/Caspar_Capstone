using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFKToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_User_UserId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_UserId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Instructor");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Student",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Instructor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ApplicationUserId",
                table: "Student",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_ApplicationUserId",
                table: "Instructor",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_AspNetUsers_ApplicationUserId",
                table: "Instructor",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_ApplicationUserId",
                table: "Student",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_AspNetUsers_ApplicationUserId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_ApplicationUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ApplicationUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_ApplicationUserId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Instructor");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_UserId",
                table: "Instructor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_User_UserId",
                table: "Instructor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
