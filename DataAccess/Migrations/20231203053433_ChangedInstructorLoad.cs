using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedInstructorLoad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLoad_Semester_SemesterId",
                table: "InstructorLoad");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "InstructorLoad",
                newName: "SemesterTypeId");

            migrationBuilder.RenameColumn(
                name: "LoadHours",
                table: "InstructorLoad",
                newName: "LoadAmount");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorLoad_SemesterId",
                table: "InstructorLoad",
                newName: "IX_InstructorLoad_SemesterTypeId");

            migrationBuilder.CreateTable(
                name: "InstructorCurrentLoad",
                columns: table => new
                {
                    InstructorCurrentLoadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentLoad = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCurrentLoad", x => x.InstructorCurrentLoadId);
                    table.ForeignKey(
                        name: "FK_InstructorCurrentLoad_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCurrentLoad_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCurrentLoad_ApplicationUserId",
                table: "InstructorCurrentLoad",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCurrentLoad_SemesterId",
                table: "InstructorCurrentLoad",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLoad_SemesterType_SemesterTypeId",
                table: "InstructorLoad",
                column: "SemesterTypeId",
                principalTable: "SemesterType",
                principalColumn: "SemesterTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLoad_SemesterType_SemesterTypeId",
                table: "InstructorLoad");

            migrationBuilder.DropTable(
                name: "InstructorCurrentLoad");

            migrationBuilder.RenameColumn(
                name: "SemesterTypeId",
                table: "InstructorLoad",
                newName: "SemesterId");

            migrationBuilder.RenameColumn(
                name: "LoadAmount",
                table: "InstructorLoad",
                newName: "LoadHours");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorLoad_SemesterTypeId",
                table: "InstructorLoad",
                newName: "IX_InstructorLoad_SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLoad_Semester_SemesterId",
                table: "InstructorLoad",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
