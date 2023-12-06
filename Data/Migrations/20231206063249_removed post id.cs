using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5510_final_project_Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class removedpostid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Post_PostId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PostId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Post");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostId",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Post_PostId",
                table: "Post",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");
        }
    }
}
