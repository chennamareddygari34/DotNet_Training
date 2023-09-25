using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelManagementApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    Key = table.Column<byte[]>(type: "bytea", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    RoomNo = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.RoomNo);
                    table.ForeignKey(
                        name: "FK_rooms_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoomNo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookings_rooms_RoomNo",
                        column: x => x.RoomNo,
                        principalTable: "rooms",
                        principalColumn: "RoomNo");
                });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Banglore", "RajaHamsa" },
                    { 2, "Agra", "Taj" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "RoomNo", "HotelId", "Price" },
                values: new object[,]
                {
                    { "1", 1, 2000m },
                    { "2", 2, 1500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_RoomNo",
                table: "bookings",
                column: "RoomNo");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_HotelId",
                table: "rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
