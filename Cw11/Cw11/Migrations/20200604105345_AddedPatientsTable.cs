using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Cw11.Migrations
{
    public partial class AddedPatientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Patient",
               columns: table => new
               {
                   IdPatient = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   FirstName = table.Column<string>(maxLength: 100, nullable: false),
                   LastName = table.Column<string>(maxLength: 100, nullable: false),
                   Birthdate = table.Column<DateTime>(type: "date", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("Patient_pk", x => x.IdPatient);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
