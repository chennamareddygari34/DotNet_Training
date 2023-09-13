using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoctorApplication.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_DoctorId",
                table: "appointment");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentNumber",
                table: "appointment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                columns: new[] { "DoctorId", "PatientID" });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "Email", "Experience", "Name", "Phone", "Speciality" },
                values: new object[,]
                {
                    { 1, "pavan@gamil.com", 2, "PavankalyanReddy", "8121288262", "Orthopedics" },
                    { 2, "babu@gamil.com", 5, "Babu", "9989355384", "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "PatientId", "Email", "PatientAge", "PatientName" },
                values: new object[,]
                {
                    { 1, "raju@gmail.com", 23, "Raju" },
                    { 2, "ramu@gmail.com", 24, "Ramu" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "DoctorId", "PatientID", "AppointmentNumber", "Date" },
                values: new object[,]
                {
                    { 1, 1, 1, "05-09-2023" },
                    { 2, 2, 2, "19-10-2023" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "DoctorId", "PatientID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "DoctorId", "PatientID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentNumber",
                table: "appointment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                column: "AppointmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_DoctorId",
                table: "appointment",
                column: "DoctorId");
        }
    }
}
