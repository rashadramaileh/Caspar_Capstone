using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    CourseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseType", x => x.CourseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DayBlock",
                columns: table => new
                {
                    DaysBlockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayBlock", x => x.DaysBlockId);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    MajorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.MajorID);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTime",
                columns: table => new
                {
                    meetingTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meetingTimeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTime", x => x.meetingTimeId);
                });

            migrationBuilder.CreateTable(
                name: "Modality",
                columns: table => new
                {
                    ModalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModalityName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModalityDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modality", x => x.ModalityId);
                });

            migrationBuilder.CreateTable(
                name: "PartOfTerm",
                columns: table => new
                {
                    PartOfTermID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partOfTermName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfTerm", x => x.PartOfTermID);
                });

            migrationBuilder.CreateTable(
                name: "PayModel",
                columns: table => new
                {
                    PayModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayModel", x => x.PayModelId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoomConfiguration",
                columns: table => new
                {
                    RoomConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomConfigName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomConfiguration", x => x.RoomConfigId);
                });

            migrationBuilder.CreateTable(
                name: "SectionStatus",
                columns: table => new
                {
                    SectionStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionStatus", x => x.SectionStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SemesterStatus",
                columns: table => new
                {
                    SemesterStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterStatusName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SemesterStatusDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterStatus", x => x.SemesterStatusID);
                });

            migrationBuilder.CreateTable(
                name: "SemesterType",
                columns: table => new
                {
                    SemesterTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterType", x => x.SemesterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TimeBlock",
                columns: table => new
                {
                    TimeBlockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeBlock", x => x.TimeBlockId);
                });

            migrationBuilder.CreateTable(
                name: "UniProgram",
                columns: table => new
                {
                    UniProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniProgram", x => x.UniProgramId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirst = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserLast = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WhoPays",
                columns: table => new
                {
                    WhoPaysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhoPaysName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhoPays", x => x.WhoPaysId);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Building_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemesterStatusId = table.Column<int>(type: "int", nullable: false),
                    SemesterTypesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterId);
                    table.ForeignKey(
                        name: "FK_Semester_SemesterStatus_SemesterStatusId",
                        column: x => x.SemesterStatusId,
                        principalTable: "SemesterStatus",
                        principalColumn: "SemesterStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Semester_SemesterType_SemesterTypesId",
                        column: x => x.SemesterTypesId,
                        principalTable: "SemesterType",
                        principalColumn: "SemesterTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursePrefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CourseNumber = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CourseDesc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    UniProgramId = table.Column<int>(type: "int", nullable: false),
                    CourseTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_CourseType_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "CourseType",
                        principalColumn: "CourseTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_UniProgram_UniProgramId",
                        column: x => x.UniProgramId,
                        principalTable: "UniProgram",
                        principalColumn: "UniProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Adjunct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Instructor_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "MajorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RoomConfigId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomId);
                    table.ForeignKey(
                        name: "FK_Classroom_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classroom_RoomConfiguration_RoomConfigId",
                        column: x => x.RoomConfigId,
                        principalTable: "RoomConfiguration",
                        principalColumn: "RoomConfigId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorRelease",
                columns: table => new
                {
                    InstructorReleaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseTimeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReleaseTimeAmount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorRelease", x => x.InstructorReleaseId);
                    table.ForeignKey(
                        name: "FK_InstructorRelease_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorRelease_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSemester",
                columns: table => new
                {
                    CourseSemesterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityTaught = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SemesterTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemester", x => x.CourseSemesterId);
                    table.ForeignKey(
                        name: "FK_CourseSemester_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSemester_SemesterType_SemesterTypeId",
                        column: x => x.SemesterTypeId,
                        principalTable: "SemesterType",
                        principalColumn: "SemesterTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreReq",
                columns: table => new
                {
                    PreReqID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCoRequisite = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreReq", x => x.PreReqID);
                    table.ForeignKey(
                        name: "FK_PreReq_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorLoad",
                columns: table => new
                {
                    InstructorLoadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadHours = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorLoad", x => x.InstructorLoadId);
                    table.ForeignKey(
                        name: "FK_InstructorLoad_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorLoad_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorUniProgram",
                columns: table => new
                {
                    InstructorProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    UniProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorUniProgram", x => x.InstructorProgramId);
                    table.ForeignKey(
                        name: "FK_InstructorUniProgram_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorUniProgram_UniProgram_UniProgramId",
                        column: x => x.UniProgramId,
                        principalTable: "UniProgram",
                        principalColumn: "UniProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorWishlist",
                columns: table => new
                {
                    InstructorWishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusID = table.Column<int>(type: "int", nullable: false),
                    InstructorRanking = table.Column<int>(type: "int", nullable: false),
                    InstructorFormat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InstructorNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingTimeId = table.Column<int>(type: "int", nullable: false),
                    DaysBlockId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: true),
                    DayBlockId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWishlist", x => x.InstructorWishlistId);
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId");
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_DayBlock_DayBlockId",
                        column: x => x.DayBlockId,
                        principalTable: "DayBlock",
                        principalColumn: "DaysBlockId");
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_MeetingTime_MeetingTimeId",
                        column: x => x.MeetingTimeId,
                        principalTable: "MeetingTime",
                        principalColumn: "meetingTimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentWishlist",
                columns: table => new
                {
                    StudentWishListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFormat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TimeblockId = table.Column<int>(type: "int", nullable: false),
                    DayBlockId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    TimeBlockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentWishlist", x => x.StudentWishListId);
                    table.ForeignKey(
                        name: "FK_StudentWishlist_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentWishlist_DayBlock_DayBlockId",
                        column: x => x.DayBlockId,
                        principalTable: "DayBlock",
                        principalColumn: "DaysBlockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentWishlist_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentWishlist_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentWishlist_TimeBlock_TimeBlockId",
                        column: x => x.TimeBlockId,
                        principalTable: "TimeBlock",
                        principalColumn: "TimeBlockId");
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    sectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maxEnrollment = table.Column<int>(type: "int", nullable: true),
                    FirstWeekEnroll = table.Column<int>(type: "int", nullable: true),
                    ThirdWeekEnroll = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClassroomId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    SectionStatusId = table.Column<int>(type: "int", nullable: true),
                    WhoPaysId = table.Column<int>(type: "int", nullable: true),
                    PayModelId = table.Column<int>(type: "int", nullable: true),
                    PartofTermId = table.Column<int>(type: "int", nullable: true),
                    ModalityId = table.Column<int>(type: "int", nullable: true),
                    MeetingTimeId = table.Column<int>(type: "int", nullable: true),
                    DayBlockId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    PartOfTermId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.sectionId);
                    table.ForeignKey(
                        name: "FK_Section_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId");
                    table.ForeignKey(
                        name: "FK_Section_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_DayBlock_DayBlockId",
                        column: x => x.DayBlockId,
                        principalTable: "DayBlock",
                        principalColumn: "DaysBlockId");
                    table.ForeignKey(
                        name: "FK_Section_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Section_MeetingTime_MeetingTimeId",
                        column: x => x.MeetingTimeId,
                        principalTable: "MeetingTime",
                        principalColumn: "meetingTimeId");
                    table.ForeignKey(
                        name: "FK_Section_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId");
                    table.ForeignKey(
                        name: "FK_Section_PartOfTerm_PartOfTermId",
                        column: x => x.PartOfTermId,
                        principalTable: "PartOfTerm",
                        principalColumn: "PartOfTermID");
                    table.ForeignKey(
                        name: "FK_Section_PayModel_PayModelId",
                        column: x => x.PayModelId,
                        principalTable: "PayModel",
                        principalColumn: "PayModelId");
                    table.ForeignKey(
                        name: "FK_Section_SectionStatus_SectionStatusId",
                        column: x => x.SectionStatusId,
                        principalTable: "SectionStatus",
                        principalColumn: "SectionStatusId");
                    table.ForeignKey(
                        name: "FK_Section_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_WhoPays_WhoPaysId",
                        column: x => x.WhoPaysId,
                        principalTable: "WhoPays",
                        principalColumn: "WhoPaysId");
                });

            migrationBuilder.CreateTable(
                name: "InstructorWishlistDetails",
                columns: table => new
                {
                    InstructorWishlistDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    InstructorRanking = table.Column<int>(type: "int", nullable: false),
                    InstructorFormat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InstructorWishlistId = table.Column<int>(type: "int", nullable: false),
                    TimeBlockId = table.Column<int>(type: "int", nullable: true),
                    DayBlockId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    DaysBlockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWishlistDetails", x => x.InstructorWishlistDetailsId);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_DayBlock_DaysBlockId",
                        column: x => x.DaysBlockId,
                        principalTable: "DayBlock",
                        principalColumn: "DaysBlockId");
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_InstructorWishlist_InstructorWishlistId",
                        column: x => x.InstructorWishlistId,
                        principalTable: "InstructorWishlist",
                        principalColumn: "InstructorWishlistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_TimeBlock_TimeBlockId",
                        column: x => x.TimeBlockId,
                        principalTable: "TimeBlock",
                        principalColumn: "TimeBlockId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Building_CampusId",
                table: "Building",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_BuildingId",
                table: "Classroom",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_RoomConfigId",
                table: "Classroom",
                column: "RoomConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseTypeId",
                table: "Course",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UniProgramId",
                table: "Course",
                column: "UniProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_CourseId",
                table: "CourseSemester",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_SemesterTypeId",
                table: "CourseSemester",
                column: "SemesterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLoad_InstructorId",
                table: "InstructorLoad",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorLoad_SemesterId",
                table: "InstructorLoad",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorRelease_SemesterId",
                table: "InstructorRelease",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorRelease_UserId",
                table: "InstructorRelease",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUniProgram_InstructorId",
                table: "InstructorUniProgram",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUniProgram_UniProgramId",
                table: "InstructorUniProgram",
                column: "UniProgramId");

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
                name: "IX_InstructorWishlist_InstructorId",
                table: "InstructorWishlist",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_MeetingTimeId",
                table: "InstructorWishlist",
                column: "MeetingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_SemesterId",
                table: "InstructorWishlist",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_CampusId",
                table: "InstructorWishlistDetails",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_DaysBlockId",
                table: "InstructorWishlistDetails",
                column: "DaysBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_InstructorWishlistId",
                table: "InstructorWishlistDetails",
                column: "InstructorWishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_SemesterId",
                table: "InstructorWishlistDetails",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_TimeBlockId",
                table: "InstructorWishlistDetails",
                column: "TimeBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PreReq_CourseId",
                table: "PreReq",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ClassroomId",
                table: "Section",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_DayBlockId",
                table: "Section",
                column: "DayBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_InstructorId",
                table: "Section",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_MeetingTimeId",
                table: "Section",
                column: "MeetingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ModalityId",
                table: "Section",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_PartOfTermId",
                table: "Section",
                column: "PartOfTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_PayModelId",
                table: "Section",
                column: "PayModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_SectionStatusId",
                table: "Section",
                column: "SectionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_SemesterId",
                table: "Section",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_WhoPaysId",
                table: "Section",
                column: "WhoPaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_SemesterStatusId",
                table: "Semester",
                column: "SemesterStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_SemesterTypesId",
                table: "Semester",
                column: "SemesterTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
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
                name: "IX_StudentWishlist_SemesterId",
                table: "StudentWishlist",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_StudentId",
                table: "StudentWishlist",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_TimeBlockId",
                table: "StudentWishlist",
                column: "TimeBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSemester");

            migrationBuilder.DropTable(
                name: "InstructorLoad");

            migrationBuilder.DropTable(
                name: "InstructorRelease");

            migrationBuilder.DropTable(
                name: "InstructorUniProgram");

            migrationBuilder.DropTable(
                name: "InstructorWishlistDetails");

            migrationBuilder.DropTable(
                name: "PreReq");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "StudentWishlist");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "InstructorWishlist");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Modality");

            migrationBuilder.DropTable(
                name: "PartOfTerm");

            migrationBuilder.DropTable(
                name: "PayModel");

            migrationBuilder.DropTable(
                name: "SectionStatus");

            migrationBuilder.DropTable(
                name: "WhoPays");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TimeBlock");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "DayBlock");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "MeetingTime");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "RoomConfiguration");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "CourseType");

            migrationBuilder.DropTable(
                name: "UniProgram");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SemesterStatus");

            migrationBuilder.DropTable(
                name: "SemesterType");

            migrationBuilder.DropTable(
                name: "Campus");
        }
    }
}
