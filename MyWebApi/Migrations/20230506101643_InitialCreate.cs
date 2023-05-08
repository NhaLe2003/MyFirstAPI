using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPaht = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPaht" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ANC@gamil.com", "Le", 0, "ABC", "Immage.abc" },
                    { 2, new DateTime(1993, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "xyz@gamil.com", "nguyen", 0, "xyz", "Immage.abc" },
                    { 3, new DateTime(1993, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DJK@gamil.com", "Tran", 0, "DJC", "Immage.abc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
