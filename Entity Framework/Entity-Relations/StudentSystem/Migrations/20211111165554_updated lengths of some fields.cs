using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class updatedlengthsofsomefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "char(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resources",
                type: "varchar(max)",
                unicode: false,
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldUnicode: false,
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Homeworks",
                type: "varchar(max)",
                unicode: false,
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldUnicode: false,
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldMaxLength: 4000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "char",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resources",
                type: "varchar",
                unicode: false,
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "nvarchar",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Homeworks",
                type: "varchar",
                unicode: false,
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4000,
                oldNullable: true);
        }
    }
}
