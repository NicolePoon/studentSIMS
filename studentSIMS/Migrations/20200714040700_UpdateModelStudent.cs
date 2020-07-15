using Microsoft.EntityFrameworkCore.Migrations;

namespace studentSIMS.Migrations
{
    public partial class UpdateModelStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timeCreated",
                table: "Student",
                newName: "TimeCreated");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Student",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "Student",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Student",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Student",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "Student",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Student",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "Student",
                newName: "timeCreated");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Student",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Student",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Student",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Student",
                newName: "emailAddress");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Student",
                newName: "studentId");
        }
    }
}
