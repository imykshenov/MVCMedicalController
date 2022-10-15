using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCMedicalController.Migrations
{
    public partial class Patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Sector",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cabinet",
                columns: table => new
                {
                    CabinetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinetNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinet", x => x.CabinetID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientSoName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    SpecialityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.SpecialityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sector_PatientId",
                table: "Sector",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sector_Patient_PatientId",
                table: "Sector",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Patient_PatientId",
                table: "Sector");

            migrationBuilder.DropTable(
                name: "Cabinet");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropIndex(
                name: "IX_Sector_PatientId",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Sector");
        }
    }
}
