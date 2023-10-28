using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviorStuWishDet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                table: "StudentWishlistDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId",
                principalTable: "StudentWishlist",
                principalColumn: "StudentWishlistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                table: "StudentWishlistDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentWishlistDetails_StudentWishlist_StudentWishlistId",
                table: "StudentWishlistDetails",
                column: "StudentWishlistId",
                principalTable: "StudentWishlist",
                principalColumn: "StudentWishlistId");
        }
    }
}
