using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovingpartoftermAGAIN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_PartOfTerm_PartOfTermId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_PartOfTermId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "PartOfTermId",
                table: "Section");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartOfTermId",
                table: "Section",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_PartOfTermId",
                table: "Section",
                column: "PartOfTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_PartOfTerm_PartOfTermId",
                table: "Section",
                column: "PartOfTermId",
                principalTable: "PartOfTerm",
                principalColumn: "PartOfTermID");
        }
    }
}
