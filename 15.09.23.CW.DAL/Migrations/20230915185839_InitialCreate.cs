using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _15._09._23.CW.DAL.Migrations
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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentCards",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentCards_Students_ID",
                        column: x => x.ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StudentCards",
                columns: new[] { "ID", "IsActive", "StartDate" },
                values: new object[,]
                {
                    { "ABC123", true, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "DEF456", true, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "GHI789", true, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "JKL012", false, new DateTime(2016, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "XYZ789", true, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateOfBirth", "LastName", "Mail", "Name", "Phone" },
                values: new object[,]
                {
                    { "1", new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sokolov", "ivan@example.com", "Ivan", "+380991234567" },
                    { "2", new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petrova", "anna@example.com", "Anna", "+380981234567" },
                    { "3", new DateTime(2002, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trynko", "oleg@example.com", "Oleg", "+380971234567" },
                    { "4", new DateTime(1999, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kozlova", "olena@example.com", "Olena", "+380961234567" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCards");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
