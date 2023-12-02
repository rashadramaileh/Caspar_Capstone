using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovingPoTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartofTermId",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Section",
                newName: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CampusId",
                table: "Section",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Campus_CampusId",
                table: "Section",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Campus_CampusId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_CampusId",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "CampusId",
                table: "Section",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "PartofTermId",
                table: "Section",
                type: "int",
                nullable: true);
        }
    }
}
