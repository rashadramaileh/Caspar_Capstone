using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InheritanceApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLoad_Instructor_InstructorId",
                table: "InstructorLoad");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorUniProgram_Instructor_InstructorId",
                table: "InstructorUniProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_Instructor_InstructorId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Instructor_InstructorId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlist_Student_StudentId",
                table: "StudentWishlist");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_StudentWishlist_StudentId",
                table: "StudentWishlist");

            migrationBuilder.DropIndex(
                name: "IX_Section_InstructorId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlist_InstructorId",
                table: "InstructorWishlist");

            migrationBuilder.DropIndex(
                name: "IX_InstructorLoad_InstructorId",
                table: "InstructorLoad");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentWishlist");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "InstructorLoad");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "StudentWishlist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Section",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "InstructorWishlist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "InstructorUniProgram",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "InstructorUniProgram",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "InstructorLoad",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Adjunct",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_ApplicationUserId",
                table: "StudentWishlist",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ApplicationUserId",
                table: "Section",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_ApplicationUserId",
                table: "InstructorWishlist",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLoad_ApplicationUserId",
                table: "InstructorLoad",
                column: "ApplicationUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLoad_AspNetUsers_ApplicationUserId",
                table: "InstructorLoad",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorUniProgram_AspNetUsers_InstructorId",
                table: "InstructorUniProgram",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_AspNetUsers_ApplicationUserId",
                table: "InstructorWishlist",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_AspNetUsers_ApplicationUserId",
                table: "Section",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlist_AspNetUsers_ApplicationUserId",
                table: "StudentWishlist",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLoad_AspNetUsers_ApplicationUserId",
                table: "InstructorLoad");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorUniProgram_AspNetUsers_InstructorId",
                table: "InstructorUniProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_AspNetUsers_ApplicationUserId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_AspNetUsers_ApplicationUserId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlist_AspNetUsers_ApplicationUserId",
                table: "StudentWishlist");

            migrationBuilder.DropIndex(
                name: "IX_StudentWishlist_ApplicationUserId",
                table: "StudentWishlist");

            migrationBuilder.DropIndex(
                name: "IX_Section_ApplicationUserId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlist_ApplicationUserId",
                table: "InstructorWishlist");

            migrationBuilder.DropIndex(
                name: "IX_InstructorLoad_ApplicationUserId",
                table: "InstructorLoad");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "StudentWishlist");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "InstructorUniProgram");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "InstructorLoad");

            migrationBuilder.DropColumn(
                name: "Adjunct",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Section",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "InstructorWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "InstructorUniProgram",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "InstructorLoad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Adjunct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Instructor_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "MajorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_StudentId",
                table: "StudentWishlist",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_InstructorId",
                table: "Section",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_InstructorId",
                table: "InstructorWishlist",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLoad_InstructorId",
                table: "InstructorLoad",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_ApplicationUserId",
                table: "Instructor",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ApplicationUserId",
                table: "Student",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLoad_Instructor_InstructorId",
                table: "InstructorLoad",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorUniProgram_Instructor_InstructorId",
                table: "InstructorUniProgram",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_Instructor_InstructorId",
                table: "InstructorWishlist",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Instructor_InstructorId",
                table: "Section",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlist_Student_StudentId",
                table: "StudentWishlist",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
