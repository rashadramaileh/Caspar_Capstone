using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class testingRoomConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_RoomConfiguration_RoomConfigId",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_RoomConfigId",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "RoomConfigId",
                table: "Classroom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomConfigId",
                table: "Classroom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_RoomConfigId",
                table: "Classroom",
                column: "RoomConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_RoomConfiguration_RoomConfigId",
                table: "Classroom",
                column: "RoomConfigId",
                principalTable: "RoomConfiguration",
                principalColumn: "RoomConfigId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
