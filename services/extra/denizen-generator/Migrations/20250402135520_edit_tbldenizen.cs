using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace denizen_generator.Migrations
{
    /// <inheritdoc />
    public partial class edit_tbldenizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "tbldenizen");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "tbldenizen");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "tbldenizen");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "tbldenizen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "tbldenizen",
                type: "text",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "tbldenizen",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "tbldenizen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "tbldenizen",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
