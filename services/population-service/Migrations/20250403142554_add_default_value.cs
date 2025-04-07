using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace population_service.Migrations
{
    /// <inheritdoc />
    public partial class add_default_value : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "tbldenizen",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "-",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "handedness",
                table: "tbldenizen",
                type: "varchar(1)",
                nullable: true,
                defaultValue: "-",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "tbldenizen",
                type: "varchar(255)",
                nullable: true,
                defaultValue: "-",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "eye_color",
                table: "tbldenizen",
                type: "varchar(3)",
                nullable: true,
                defaultValue: "-",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "blood_type",
                table: "tbldenizen",
                type: "varchar(3)",
                nullable: true,
                defaultValue: "-",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "birth_date",
                table: "tbldenizen",
                type: "varchar(12)",
                nullable: true,
                defaultValue: "0000-00-00",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "birth_time",
                table: "tbldenizen",
                type: "varchar(6)",
                nullable: true,
                defaultValue: "000000")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "tbldenizen",
                type: "varchar(20)",
                nullable: true,
                defaultValue: "Other")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "is_delete",
                table: "tbldenizen",
                type: "varchar(1)",
                nullable: true,
                defaultValue: "0")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birth_time",
                table: "tbldenizen");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "tbldenizen");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "tbldenizen");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "tbldenizen",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "-")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "handedness",
                table: "tbldenizen",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true,
                oldDefaultValue: "-")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "tbldenizen",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true,
                oldDefaultValue: "-")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "eye_color",
                table: "tbldenizen",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldNullable: true,
                oldDefaultValue: "-")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "blood_type",
                table: "tbldenizen",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldNullable: true,
                oldDefaultValue: "-")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "birth_date",
                table: "tbldenizen",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true,
                oldDefaultValue: "0000-00-00")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
