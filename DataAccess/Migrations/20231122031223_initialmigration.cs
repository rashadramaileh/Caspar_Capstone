using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomFeature",
                columns: table => new
                {
                    ClassroomFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomFeatureName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomFeature", x => x.ClassroomFeatureId);
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    CourseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    DayName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    meetingTimeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    ModalityDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdditionalWishlistInfo = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    PartOfTermName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    PayType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayModel", x => x.PayModelId);
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
                    StatusDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    SemesterStatusDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    TimeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    WhoPaysName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhoPays", x => x.WhoPaysId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    SemesterTypeId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Semester_SemesterType_SemesterTypeId",
                        column: x => x.SemesterTypeId,
                        principalTable: "SemesterType",
                        principalColumn: "SemesterTypeId",
                        onDelete: ReferentialAction.Cascade);
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
                    CourseTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adjunct = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Instructor_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
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
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
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
                    PreReqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCoRequisite = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreReq", x => x.PreReqId);
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
                        principalColumn: "InstructorId",
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
                        principalColumn: "InstructorId",
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
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWishlist", x => x.InstructorWishlistId);
                    table.ForeignKey(
                        name: "FK_InstructorWishlist_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "InstructorId",
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
                    StudentWishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentWishlist", x => x.StudentWishlistId);
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
                });

            migrationBuilder.CreateTable(
                name: "ClassroomFeaturePossession",
                columns: table => new
                {
                    FeaturePossessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomFeaturePossession", x => x.FeaturePossessionId);
                    table.ForeignKey(
                        name: "FK_ClassroomFeaturePossession_ClassroomFeature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "ClassroomFeature",
                        principalColumn: "ClassroomFeatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomFeaturePossession_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxEnrollment = table.Column<int>(type: "int", nullable: true),
                    FirstWeekEnroll = table.Column<int>(type: "int", nullable: true),
                    ThirdWeekEnroll = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
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
                        principalColumn: "InstructorId");
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
                    InstructorRanking = table.Column<int>(type: "int", nullable: false),
                    InstructorNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    InstructorWishlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWishlistDetails", x => x.InstructorWishlistDetailsId);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorWishlistDetails_InstructorWishlist_InstructorWishlistId",
                        column: x => x.InstructorWishlistId,
                        principalTable: "InstructorWishlist",
                        principalColumn: "InstructorWishlistId");
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
                        name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                        column: x => x.StudentWishlistId,
                        principalTable: "StudentWishlist",
                        principalColumn: "StudentWishlistId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "InstructorTime",
                columns: table => new
                {
                    InstructorTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysBlockId = table.Column<int>(type: "int", nullable: true),
                    MeetingTimeId = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    InstructorWishlistModalityId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_InstructorTime_DayBlock_DaysBlockId",
                        column: x => x.DaysBlockId,
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Building_CampusId",
                table: "Building",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_BuildingId",
                table: "Classroom",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomFeaturePossession_ClassroomId",
                table: "ClassroomFeaturePossession",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomFeaturePossession_FeatureId",
                table: "ClassroomFeaturePossession",
                column: "FeatureId");

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
                name: "IX_Instructor_UserId",
                table: "Instructor",
                column: "UserId");

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
                name: "IX_InstructorTime_CampusId",
                table: "InstructorTime",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_DaysBlockId",
                table: "InstructorTime",
                column: "DaysBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_InstructorWishlistModalityId",
                table: "InstructorTime",
                column: "InstructorWishlistModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTime_MeetingTimeId",
                table: "InstructorTime",
                column: "MeetingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUniProgram_InstructorId",
                table: "InstructorUniProgram",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUniProgram_UniProgramId",
                table: "InstructorUniProgram",
                column: "UniProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_InstructorId",
                table: "InstructorWishlist",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlist_SemesterId",
                table: "InstructorWishlist",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_CourseId",
                table: "InstructorWishlistDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistDetails_InstructorWishlistId",
                table: "InstructorWishlistDetails",
                column: "InstructorWishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistModality_InstructorWishListDetailsId",
                table: "InstructorWishlistModality",
                column: "InstructorWishListDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWishlistModality_ModalityId",
                table: "InstructorWishlistModality",
                column: "ModalityId");

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
                name: "IX_Semester_SemesterTypeId",
                table: "Semester",
                column: "SemesterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

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
                name: "IX_StudentWishlist_SemesterId",
                table: "StudentWishlist",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlist_StudentId",
                table: "StudentWishlist",
                column: "StudentId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClassroomFeaturePossession");

            migrationBuilder.DropTable(
                name: "CourseSemester");

            migrationBuilder.DropTable(
                name: "InstructorLoad");

            migrationBuilder.DropTable(
                name: "InstructorRelease");

            migrationBuilder.DropTable(
                name: "InstructorTime");

            migrationBuilder.DropTable(
                name: "InstructorUniProgram");

            migrationBuilder.DropTable(
                name: "PartOfTerm");

            migrationBuilder.DropTable(
                name: "PreReq");

            migrationBuilder.DropTable(
                name: "Rankings");

            migrationBuilder.DropTable(
                name: "RoomConfiguration");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "StudentTime");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ClassroomFeature");

            migrationBuilder.DropTable(
                name: "InstructorWishlistModality");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "DayBlock");

            migrationBuilder.DropTable(
                name: "MeetingTime");

            migrationBuilder.DropTable(
                name: "PayModel");

            migrationBuilder.DropTable(
                name: "SectionStatus");

            migrationBuilder.DropTable(
                name: "WhoPays");

            migrationBuilder.DropTable(
                name: "StudentWishlistModality");

            migrationBuilder.DropTable(
                name: "TimeBlock");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "InstructorWishlistDetails");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Modality");

            migrationBuilder.DropTable(
                name: "StudentWishlistDetails");

            migrationBuilder.DropTable(
                name: "InstructorWishlist");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "StudentWishlist");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "CourseType");

            migrationBuilder.DropTable(
                name: "UniProgram");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "SemesterStatus");

            migrationBuilder.DropTable(
                name: "SemesterType");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
