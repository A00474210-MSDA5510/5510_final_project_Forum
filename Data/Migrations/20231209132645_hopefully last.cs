using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5510_final_project_Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class hopefullylast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isSubbed",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSubbed",
                table: "AspNetUsers");
        }
    }
}
