using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorOffice.Migrations
{
    public partial class DoctorModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialties_Specialty_SpecialtyId",
                table: "DoctorSpecialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialties_Specialties_SpecialtyId",
                table: "DoctorSpecialties",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialties_Specialties_SpecialtyId",
                table: "DoctorSpecialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialties_Specialty_SpecialtyId",
                table: "DoctorSpecialties",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
