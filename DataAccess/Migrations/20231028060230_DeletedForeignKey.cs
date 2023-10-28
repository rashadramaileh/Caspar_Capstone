using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeletedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentWishlistDetails_StudentWishlistId",
                table: "StudentWishlistDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentWishlistDetails_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlistDetails_InstructorWishlist_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId",
                principalTable: "InstructorWishlist",
                principalColumn: "InstructorWishlistId");
        }
    }
}
