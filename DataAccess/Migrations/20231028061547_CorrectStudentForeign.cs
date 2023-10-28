using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CorrectStudentForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlistDetails_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId",
                principalTable: "StudentWishlist",
                principalColumn: "StudentWishlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                table: "StudentWishlistDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudentWishlistDetails_StudentWishlistId",
                table: "StudentWishlistDetails");
        }
    }
}
