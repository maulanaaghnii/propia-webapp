using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace population_service.Migrations
{
    /// <inheritdoc />
    public partial class change_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "tbldenizen",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "tbldenizen",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "tbldenizen",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EyeColor",
                table: "tbldenizen",
                newName: "eye_color");

            migrationBuilder.RenameColumn(
                name: "BloodType",
                table: "tbldenizen",
                newName: "blood_type");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "tbldenizen",
                newName: "birth_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "tbldenizen",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "tbldenizen",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "tbldenizen",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "eye_color",
                table: "tbldenizen",
                newName: "EyeColor");

            migrationBuilder.RenameColumn(
                name: "blood_type",
                table: "tbldenizen",
                newName: "BloodType");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "tbldenizen",
                newName: "BirthDate");
        }
    }
}
