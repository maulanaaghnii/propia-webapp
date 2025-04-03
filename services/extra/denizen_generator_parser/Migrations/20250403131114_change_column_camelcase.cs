using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace denizen_generator_parser.Migrations
{
    /// <inheritdoc />
    public partial class change_column_camelcase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamps",
                table: "tbldenizen_generator_monitoring",
                newName: "timestamps");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tbldenizen_generator_monitoring",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "tbldenizen_generator_monitoring",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Loss",
                table: "tbldenizen_generator_monitoring",
                newName: "loss");

            migrationBuilder.RenameColumn(
                name: "Inserted",
                table: "tbldenizen_generator_monitoring",
                newName: "inserted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbldenizen_generator_monitoring",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartYear",
                table: "tbldenizen_generator_monitoring",
                newName: "start_year");

            migrationBuilder.RenameColumn(
                name: "EndYear",
                table: "tbldenizen_generator_monitoring",
                newName: "end_year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timestamps",
                table: "tbldenizen_generator_monitoring",
                newName: "Timestamps");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "tbldenizen_generator_monitoring",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "tbldenizen_generator_monitoring",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "loss",
                table: "tbldenizen_generator_monitoring",
                newName: "Loss");

            migrationBuilder.RenameColumn(
                name: "inserted",
                table: "tbldenizen_generator_monitoring",
                newName: "Inserted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbldenizen_generator_monitoring",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_year",
                table: "tbldenizen_generator_monitoring",
                newName: "StartYear");

            migrationBuilder.RenameColumn(
                name: "end_year",
                table: "tbldenizen_generator_monitoring",
                newName: "EndYear");
        }
    }
}
