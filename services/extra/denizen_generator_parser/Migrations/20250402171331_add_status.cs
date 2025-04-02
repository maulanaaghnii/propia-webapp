using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace denizen_generator_parser.Migrations
{
    /// <inheritdoc />
    public partial class add_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tbldenizen_generator_monitoring",
                type: "varchar(20)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbldenizen_generator_monitoring");
        }
    }
}
