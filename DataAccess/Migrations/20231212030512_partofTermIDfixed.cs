using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class partofTermIDfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_PartOfTerm_PartOfTermId",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "PartOfTermId",
                table: "Section",
                newName: "PartOfTermID");

            migrationBuilder.RenameIndex(
                name: "IX_Section_PartOfTermId",
                table: "Section",
                newName: "IX_Section_PartOfTermID");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_PartOfTerm_PartOfTermID",
                table: "Section",
                column: "PartOfTermID",
                principalTable: "PartOfTerm",
                principalColumn: "PartOfTermID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_PartOfTerm_PartOfTermID",
                table: "Section");

            migrationBuilder.RenameColumn(
                name: "PartOfTermID",
                table: "Section",
                newName: "PartOfTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_PartOfTermID",
                table: "Section",
                newName: "IX_Section_PartOfTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_PartOfTerm_PartOfTermId",
                table: "Section",
                column: "PartOfTermId",
                principalTable: "PartOfTerm",
                principalColumn: "PartOfTermID");
        }
    }
}
