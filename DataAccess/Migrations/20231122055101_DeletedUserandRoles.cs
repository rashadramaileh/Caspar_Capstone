using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeletedUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorRelease_User_UserId",
                table: "InstructorRelease");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_InstructorRelease_UserId",
                table: "InstructorRelease");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InstructorRelease");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "InstructorRelease",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorRelease_ApplicationUserId",
                table: "InstructorRelease",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorRelease_AspNetUsers_ApplicationUserId",
                table: "InstructorRelease",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorRelease_AspNetUsers_ApplicationUserId",
                table: "InstructorRelease");

            migrationBuilder.DropIndex(
                name: "IX_InstructorRelease_ApplicationUserId",
                table: "InstructorRelease");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "InstructorRelease");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "InstructorRelease",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserFirst = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserLast = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
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

            migrationBuilder.CreateIndex(
                name: "IX_InstructorRelease_UserId",
                table: "InstructorRelease",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorRelease_User_UserId",
                table: "InstructorRelease",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
