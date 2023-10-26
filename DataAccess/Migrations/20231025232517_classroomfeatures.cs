using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class classroomfeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_User_UserId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorLoad_Instructor_InstructorId",
                table: "InstructorLoad");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorUniProgram_Instructor_InstructorId",
                table: "InstructorUniProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_Campus_CampusId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_Course_CourseId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_DayBlock_DayBlockId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_Instructor_InstructorId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlist_MeetingTime_MeetingTimeId",
                table: "InstructorWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlistDetails_Campus_CampusId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlistDetails_DayBlock_DaysBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlistDetails_Semester_SemesterId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorWishlistDetails_TimeBlock_TimeBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Instructor_InstructorId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlist_Course_CourseId",
                table: "StudentWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlist_DayBlock_DayBlockId",
                table: "StudentWishlist");

            migrationBuilder.DropIndex(
                name: "IX_StudentWishlist_CourseId",
                table: "StudentWishlist");

            migrationBuilder.DropIndex(
                name: "IX_StudentWishlist_DayBlockId",
                table: "StudentWishlist");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlistDetails_CampusId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlistDetails_DaysBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlistDetails_TimeBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlist_CampusId",
                table: "InstructorWishlist");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlist_CourseId",
                table: "InstructorWishlist");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlist_DayBlockId",
                table: "InstructorWishlist");

            migrationBuilder.DropIndex(
                name: "IX_InstructorWishlist_MeetingTimeId",
                table: "InstructorWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentWishlist");

            migrationBuilder.DropColumn(
                name: "DayBlockId",
                table: "StudentWishlist");

            migrationBuilder.DropColumn(
                name: "StudentFormat",
                table: "StudentWishlist");

            migrationBuilder.DropColumn(
                name: "TimeBlockId",
                table: "StudentWishlist");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropColumn(
                name: "DayBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropColumn(
                name: "DaysBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropColumn(
                name: "InstructorFormat",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropColumn(
                name: "TimeBlockId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "DayBlockId",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "DaysBlockId",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "InstructorFormat",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "InstructorNotes",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "InstructorRanking",
                table: "InstructorWishlist");

            migrationBuilder.DropColumn(
                name: "MeetingTimeId",
                table: "InstructorWishlist");

            migrationBuilder.RenameColumn(
                name: "StudentWishListId",
                table: "StudentWishlist",
                newName: "StudentWishlistId");

            migrationBuilder.RenameColumn(
                name: "partOfTermName",
                table: "PartOfTerm",
                newName: "PartOfTermName");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "InstructorWishlistDetails",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorWishlistDetails_SemesterId",
                table: "InstructorWishlistDetails",
                newName: "IX_InstructorWishlistDetails_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "InstructorNotes",
                table: "InstructorWishlistDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstructorId");

            migrationBuilder.CreateTable(
                name: "InstructorWishlistModality",
                columns: table => new
                {
                    InstructorWishlistModalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModalityId = table.Column<int>(type: "int", nullable: true),
                    InstructorWishListDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWishlistModality", x => x.InstructorWishlistModalityId);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistModality_InstructorWishlistDetails_InstructorWishListDetailsId",
                        column: x => x.InstructorWishListDetailsId,
                        principalTable: "InstructorWishlistDetails",
                        principalColumn: "InstructorWishlistDetailsId");
                    table.ForeignKey(
                        name: "FK_InstructorWishlistModality_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId");
                });

            migrationBuilder.CreateTable(
                name: "Rankings",
                columns: table => new
                {
                    RankingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => x.RankingId);
                });

            migrationBuilder.CreateTable(
                name: "StudentWishlistDetails",
                columns: table => new
                {
                    StudentWishlistDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentWishlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentWishlistDetails", x => x.StudentWishlistDetailsId);
                    table.ForeignKey(
                        name: "FK_StudentWishlistDetails_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentWishlistDetails_InstructorWishlist_StudentWishlistId",
                        column: x => x.StudentWishlistId,
                        principalTable: "InstructorWishlist",
                        principalColumn: "InstructorWishlistId");
                });

            migrationBuilder.CreateTable(
                name: "InstructorTime",
                columns: table => new
                {
                    InstructorTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysBlockId = table.Column<int>(type: "int", nullable: true),
                    MeetingTimeId = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    InstructorWishlistModalityId = table.Column<int>(type: "int", nullable: false),
                    DayBlockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTime", x => x.InstructorTimeId);
                    table.ForeignKey(
                        name: "FK_InstructorTime_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorTime_DayBlock_DayBlockId",
                        column: x => x.DayBlockId,
                        principalTable: "DayBlock",
                        principalColumn: "DaysBlockId");
                    table.ForeignKey(
                        name: "FK_InstructorTime_InstructorWishlistModality_InstructorWishlistModalityId",
                        column: x => x.InstructorWishlistModalityId,
                        principalTable: "InstructorWishlistModality",
                        principalColumn: "InstructorWishlistModalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorTime_MeetingTime_MeetingTimeId",
                        column: x => x.MeetingTimeId,
                        principalTable: "MeetingTime",
                        principalColumn: "meetingTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentWishlistModality",
                columns: table => new
                {
                    StudentWishlistModalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModalityId = table.Column<int>(type: "int", nullable: true),
                    StudentWishListDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentWishlistModality", x => x.StudentWishlistModalityId);
                    table.ForeignKey(
                        name: "FK_StudentWishlistModality_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId");
                    table.ForeignKey(
                        name: "FK_StudentWishlistModality_StudentWishlistDetails_StudentWishListDetailsId",
                        column: x => x.StudentWishListDetailsId,
                        principalTable: "StudentWishlistDetails",
                        principalColumn: "StudentWishlistDetailsId");
                });

            migrationBuilder.CreateTable(
                name: "StudentTime",
                columns: table => new
                {
                    StudentTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeBlockId = table.Column<int>(type: "int", nullable: true),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    StudentWishlistModalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTime", x => x.StudentTimeId);
                    table.ForeignKey(
                        name: "FK_StudentTime_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTime_StudentWishlistModality_StudentWishlistModalityId",
                        column: x => x.StudentWishlistModalityId,
                        principalTable: "StudentWishlistModality",
                        principalColumn: "StudentWishlistModalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTime_TimeBlock_TimeBlockId",
                        column: x => x.TimeBlockId,
                        principalTable: "TimeBlock",
                        principalColumn: "TimeBlockId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_UserId",
                table: "Instructor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_CampusId",
                table: "InstructorTime",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_DayBlockId",
                table: "InstructorTime",
                column: "DayBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_InstructorWishlistModalityId",
                table: "InstructorTime",
                column: "InstructorWishlistModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_MeetingTimeId",
                table: "InstructorTime",
                column: "MeetingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistModality_InstructorWishListDetailsId",
                table: "InstructorWishlistModality",
                column: "InstructorWishListDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistModality_ModalityId",
                table: "InstructorWishlistModality",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTime_CampusId",
                table: "StudentTime",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTime_StudentWishlistModalityId",
                table: "StudentTime",
                column: "StudentWishlistModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTime_TimeBlockId",
                table: "StudentTime",
                column: "TimeBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlistDetails_CourseId",
                table: "StudentWishlistDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlistDetails_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlistModality_ModalityId",
                table: "StudentWishlistModality",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlistModality_StudentWishListDetailsId",
                table: "StudentWishlistModality",
                column: "StudentWishListDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_User_UserId",
                table: "Instructor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

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
                name: "FK_InstructorWishlistDetails_Course_CourseId",
                table: "InstructorWishlistDetails",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Instructor_InstructorId",
                table: "Section",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_User_UserId",
                table: "Instructor");

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
                name: "FK_InstructorWishlistDetails_Course_CourseId",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Instructor_InstructorId",
                table: "Section");

            migrationBuilder.DropTable(
                name: "InstructorTime");

            migrationBuilder.DropTable(
                name: "Rankings");

            migrationBuilder.DropTable(
                name: "StudentTime");

            migrationBuilder.DropTable(
                name: "InstructorWishlistModality");

            migrationBuilder.DropTable(
                name: "StudentWishlistModality");

            migrationBuilder.DropTable(
                name: "StudentWishlistDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_UserId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstructorNotes",
                table: "InstructorWishlistDetails");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Instructor");

            migrationBuilder.RenameColumn(
                name: "StudentWishlistId",
                table: "StudentWishlist",
                newName: "StudentWishListId");

            migrationBuilder.RenameColumn(
                name: "PartOfTermName",
                table: "PartOfTerm",
                newName: "partOfTermName");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "InstructorWishlistDetails",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorWishlistDetails_CourseId",
                table: "InstructorWishlistDetails",
                newName: "IX_InstructorWishlistDetails_SemesterId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayBlockId",
                table: "StudentWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentFormat",
                table: "StudentWishlist",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeBlockId",
                table: "StudentWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "InstructorWishlistDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayBlockId",
                table: "InstructorWishlistDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaysBlockId",
                table: "InstructorWishlistDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorFormat",
                table: "InstructorWishlistDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeBlockId",
                table: "InstructorWishlistDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "InstructorWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "InstructorWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayBlockId",
                table: "InstructorWishlist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DaysBlockId",
                table: "InstructorWishlist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorFormat",
                table: "InstructorWishlist",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorNotes",
                table: "InstructorWishlist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorRanking",
                table: "InstructorWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeetingTimeId",
                table: "InstructorWishlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_CourseId",
                table: "StudentWishlist",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_DayBlockId",
                table: "StudentWishlist",
                column: "DayBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_CampusId",
                table: "InstructorWishlistDetails",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_DaysBlockId",
                table: "InstructorWishlistDetails",
                column: "DaysBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_TimeBlockId",
                table: "InstructorWishlistDetails",
                column: "TimeBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_CampusId",
                table: "InstructorWishlist",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_CourseId",
                table: "InstructorWishlist",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_DayBlockId",
                table: "InstructorWishlist",
                column: "DayBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_MeetingTimeId",
                table: "InstructorWishlist",
                column: "MeetingTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_User_UserId",
                table: "Instructor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorLoad_Instructor_InstructorId",
                table: "InstructorLoad",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorUniProgram_Instructor_InstructorId",
                table: "InstructorUniProgram",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_Campus_CampusId",
                table: "InstructorWishlist",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_Course_CourseId",
                table: "InstructorWishlist",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_DayBlock_DayBlockId",
                table: "InstructorWishlist",
                column: "DayBlockId",
                principalTable: "DayBlock",
                principalColumn: "DaysBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_Instructor_InstructorId",
                table: "InstructorWishlist",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlist_MeetingTime_MeetingTimeId",
                table: "InstructorWishlist",
                column: "MeetingTimeId",
                principalTable: "MeetingTime",
                principalColumn: "meetingTimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlistDetails_Campus_CampusId",
                table: "InstructorWishlistDetails",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlistDetails_DayBlock_DaysBlockId",
                table: "InstructorWishlistDetails",
                column: "DaysBlockId",
                principalTable: "DayBlock",
                principalColumn: "DaysBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlistDetails_Semester_SemesterId",
                table: "InstructorWishlistDetails",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorWishlistDetails_TimeBlock_TimeBlockId",
                table: "InstructorWishlistDetails",
                column: "TimeBlockId",
                principalTable: "TimeBlock",
                principalColumn: "TimeBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Instructor_InstructorId",
                table: "Section",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlist_Course_CourseId",
                table: "StudentWishlist",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlist_DayBlock_DayBlockId",
                table: "StudentWishlist",
                column: "DayBlockId",
                principalTable: "DayBlock",
                principalColumn: "DaysBlockId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
