using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCMedicalController.Migrations
{
    public partial class Doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Speciality",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Sector",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Cabinet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorSoName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoctorFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speciality_DoctorID",
                table: "Speciality",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_DoctorID",
                table: "Sector",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Cabinet_DoctorID",
                table: "Cabinet",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabinet_Doctor_DoctorID",
                table: "Cabinet",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sector_Doctor_DoctorID",
                table: "Sector",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speciality_Doctor_DoctorID",
                table: "Speciality",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabinet_Doctor_DoctorID",
                table: "Cabinet");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Doctor_DoctorID",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_Speciality_Doctor_DoctorID",
                table: "Speciality");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Speciality_DoctorID",
                table: "Speciality");

            migrationBuilder.DropIndex(
                name: "IX_Sector_DoctorID",
                table: "Sector");

            migrationBuilder.DropIndex(
                name: "IX_Cabinet_DoctorID",
                table: "Cabinet");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Speciality");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Cabinet");
        }
    }
}
