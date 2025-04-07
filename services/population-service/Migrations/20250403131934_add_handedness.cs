using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace population_service.Migrations
{
    /// <inheritdoc />
    public partial class add_handedness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "handedness",
                table: "tbldenizen",
                type: "varchar(5)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "handedness",
                table: "tbldenizen");
        }
    }
}
