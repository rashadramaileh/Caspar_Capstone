using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class classfeatpossession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassroomFeature",
                columns: table => new
                {
                    ClassroomFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomFeatureName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomFeature", x => x.ClassroomFeatureId);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomFeaturePossession",
                columns: table => new
                {
                    FeaturePossessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomFeaturePossession_ClassroomId",
                table: "ClassroomFeaturePossession",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomFeaturePossession_FeatureId",
                table: "ClassroomFeaturePossession",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomFeaturePossession");

            migrationBuilder.DropTable(
                name: "ClassroomFeature");
        }
    }
}
