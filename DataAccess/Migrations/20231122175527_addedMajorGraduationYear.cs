using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedMajorGraduationYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MajorId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "GraduationYear",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraduationYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MajorId",
                table: "AspNetUsers",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Major_MajorId",
                table: "AspNetUsers",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
